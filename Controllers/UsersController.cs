using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
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
        // getId
        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Users>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetUserById(int userId)
        {
            var user = _userServices.GetUsersId(userId);
            if (user == null)
            {
                return NotFound(new { status = 404, message = "User not found" });
            }
            return Ok(new { status = 200, message = "Success", data = user });
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
            userAdd.Role = Role.USER;
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
            if (!_userServices.isCheckEmail(request.Email))
            {
                return NotFound(new { status = 404, message = "Email not found" });
            }

            if (!_userServices.isCheckPassword(request.Password))
            {
                return BadRequest(new { status = 400, message = "Invalid password" });
            }
            _userServices.UsersLogin(request.Email, request.Password);
            return Ok(new { status = 200, message = "Login successful" });
        }
    }
}
