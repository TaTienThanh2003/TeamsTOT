using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using backTOT.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backTOT.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUserServices _userServices;
        private AuthService _authServices;
        private LeverService _leverService;
        private IMapper _mapper;
        public UsersController(IUserServices userServices,LeverService leverService, IMapper mapper, AuthService authServices)
        {
            _userServices = userServices;
            _leverService = leverService;
            _authServices = authServices;
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
        //[HttpGet("getTeacher")]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<Users>))]
        //[ProducesResponseType(404)]
        //public IActionResult GetAllTeacher()
        //{
        //    var teacher = _userServices.GetTeacher();
        //    if (teacher == null)
        //    {
        //        return NotFound(new { status = 404, message = "No teacher found" });
        //    }
        //    return Ok(new { status = 200, message = "Success", data = teacher });
        //}
        // getId
        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Users>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetUserById(Guid userId)
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
        public IActionResult DeleteUser(Guid id)
        {
            var ischeck = _userServices.ischeckId(id);
            if (ischeck) return NotFound("Id không tồn tại");
            _userServices.deleteUser(id);
            return Ok(new { status = 200, message = "delete Success" });
        }
        [HttpPut("updateUser/{userid}")]
        public IActionResult UpdateCourse(Guid userid, [FromBody] UserDto userDto)
        {
            var user = _userServices.GetUserId(userid);
            if (user == null)
                return NotFound("Không tìm thấy user");
            var users = _mapper.Map<Users>(userDto);
            users.Id = user.Id;
            var ischeck = _userServices.updateUser(users);
            return Ok(new { status = 200, message = "Success", data = userDto });
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            try
            {
                var result = await _authServices.ChangePasswordAsync(dto.UserId, dto.OldPassword, dto.NewPassword);

                if (!result)
                    return BadRequest("User not found or Incorrect old password");

                return Ok("Password changed successfully and confirmation email sent");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("level/{userId}")]
        public async Task<IActionResult> GetUserLevel(Guid userId)
        {
            var (score, level) = await _leverService.CalculateUserLevelAsync(userId);

            return Ok(new
            {
                UserId = userId,
                Score = score,
                Level = level
            });
        }
        [HttpGet("rankings")]
        public async Task<IActionResult> GetTopUserRankings()
        {
            var users =  _userServices.GetUsers(); // ✅ thêm await
            var rankings = new List<UserRankingDto>();

            foreach (var user in users)
            {
                var (totalScore, level) = await _leverService.CalculateUserLevelAsync(user.Id); // ✅ thêm await

                rankings.Add(new UserRankingDto
                {
                    UserId = user.Id,
                    FullName = user.FullName,
                    Score = totalScore,
                    Level = level
                });
            }

            var top10 = rankings
                .OrderByDescending(r => r.Score)
                .ThenBy(r => r.UserId)
                .Take(10)
                .ToList();

            return Ok(top10);
        }

    }
}
