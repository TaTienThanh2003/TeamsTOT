using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Helpers;
using backTOT.Interface;
using backTOT.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IUserServices _userServices;
        private AuthService _authService;
        public AuthController(AuthService authService, IUserServices userServices)
        {
            _authService = authService;
            _userServices = userServices;
        }
        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(Users))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetUserLogin([FromBody] LoginRequest request)
        {
            var isGmail = _userServices.findUserByEmail(request.Email);
            if (isGmail == null)
            {
                return NotFound(new { status = 404, message = "Email not found" });
            }
            // So sánh mật khẩu tại đây thông qua UsersLogin
            var auth = _authService.UsersLogin(request.Email, request.Password);
            if (auth == null)
            {
                return Unauthorized(new { message = "Sai email hoặc mật khẩu" });
            }
            CookieHelper.SetAuthCookies(Response, auth);
            return Ok(new { status = 200, message = "Login successful" , data = auth});
        }
        [HttpPost("refresh-token")]
        public IActionResult Refresh(string refreshToken)
        {
            var auth = _authService.RefreshToken(refreshToken);
            if (auth == null) return Unauthorized("Refresh token không hợp lệ");
            CookieHelper.SetAuthCookies(Response, auth);
            return Ok(new { message = "Token đã được làm mới" });
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            CookieHelper.ClearAuthCookie(Response);
            return Ok(new { message = "Đăng xuất thành công" });
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserDto userDto)
        {
            var result = await _authService.RegisterUserAsync(userDto);
            if (!result)
                return Conflict(new { status = 409, message = "Email đã tồn tại hoặc dữ liệu không hợp lệ" });

            return Ok(new { status = 200, message = "Vui lòng kiểm tra email để xác nhận tài khoản" });
        }

        [HttpGet("confirmUser")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token)
        {
            var result = await _authService.ConfirmEmailAsync(token);
            if (!result)
                return BadRequest(new { status = 400, message = "Token không hợp lệ hoặc đã hết hạn" });

            return Ok(new { status = 200, message = "Tài khoản đã xác thực thành công" });
        }
    }
}
