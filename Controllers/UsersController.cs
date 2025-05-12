using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUserServices _userServices;
        private IMapper _mapper;
        public UsersController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }
        // getAll
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Users>))]
        [ProducesResponseType(404)]
        public IActionResult GetAllUsers()
        {
            var user = _userServices.GetUsers();
            if (user == null)
            {
                return NotFound(new { status = 404, message = "No users found" });
            }
            return Ok(new { status = 200, message = "Success", data = user });
        }
        // getAllTeacher
        [HttpGet("getTeacher")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Users>))]
        [ProducesResponseType(404)]
        public IActionResult GetAllTeacher()
        {
            var teacher = _userServices.GetTeacher();
            if (teacher == null)
            {
                return NotFound(new { status = 404, message = "No teacher found" });
            }
            return Ok(new { status = 200, message = "Success", data = teacher });
        }
        // getId
        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Users>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetUserById(int userId)
        {
            var user = _userServices.GetUserId(userId);
            if (user == null)
            {
                return NotFound(new { status = 404, message = "User not found" });
            }
            return Ok(new { status = 200, message = "Success", data = user });
        }
        // deleteCourse
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var ischeck = _userServices.ischeckId(id);
            if (ischeck) return NotFound("Id không tồn tại");
            _userServices.deleteUser(id);
            return Ok(new { status = 200, message = "delete Success" });
        }
        [HttpPut("updateUser/{userid}")]
        public IActionResult UpdateCourse(int userid, [FromBody] UserDto userDto)
        {
            var user = _userServices.GetUserId(userid);
            if (user == null)
                return NotFound("Không tìm thấy user");
            var users = _mapper.Map<Users>(userDto);
            users.Id = user.Id;
            var ischeck = _userServices.updateUser(users);
            return Ok(new { status = 200, message = "Success", data = userDto });
        }
        [HttpPost("signup")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult GetUserSignUp([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest(new { status = 400, message = "Invalid user data" });
            }
            if (_userServices.isCheckEmail(userDto.Email))
            {
                return Conflict(new { status = 409, message = "Email already exists" });
            }
            var userAdd = _mapper.Map<Users>(userDto);
            var result = _userServices.UsersSignIn(userAdd);
            if (result == null)
            {
                return StatusCode(500, new { status = 500, message = "An error occurred while creating user" });
            }
            return Created("", new { status = 201, message = "Add Successfully", userAdd = result });
        }
        [HttpPost("signin")]
        [ProducesResponseType(200, Type = typeof(Users))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetUserLogin([FromBody] LoginRequest request)
        {
            var user = _userServices.findUserByEmail(request.Email);
            if (user == null)
            {
                return NotFound(new { status = 404, message = "Email not found" });
            }
            // So sánh mật khẩu tại đây thông qua UsersLogin
            var isLoginValid = _userServices.UsersLogin(request.Email, request.Password);
            if (!isLoginValid)
            {
                return BadRequest(new { status = 400, message = "Invalid password" });
            }

            var userConvert = _mapper.Map<UserLoginDto>(user);
            return Ok(new { status = 200, message = "Login successful", data = userConvert });
        }

    }
}
