
using System.Collections;
using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserControlles : Controller
    {
        private IUserServices _userServices;
        private IMapper _mapper;
        public UserControlles(IUserServices userServices, IMapper mapper) {
            _userServices = userServices;
            _mapper = mapper;
        }
        // getAll
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Users>))]
        [ProducesResponseType(404)]
        public IActionResult GetAllUsers() {
            var user = _userServices.GetUsers();
            if (user == null)
            {
                return BadRequest("No users found");
            }
            return Ok(user);
        }
        // getId
        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Users>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetUserById(int userId)
        {
            var  user = _userServices.GetUsersId(userId);
            if (user == null)
            {
                return BadRequest("No users found");
            }
            return Ok(user);
        }
        [HttpPost("signin")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Users>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetUserSignIn([FromBody] Users user) 
        {
                if(user == null)
                {
                return BadRequest("Invalid user data");
                }
                if (_userServices.isCheckEmail(user.Email))
                {
                    return BadRequest("Email already exists");
                }
                var userAdd = _userServices.UsersSignIn(user);
                if (userAdd == null)
                {
                    return NotFound("User could not be created");
                }
                return Created("",new {status = 201, message = "Add Successfully",user});
        }
        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Users>))]
        [ProducesResponseType(400)]
        public IActionResult GetUserLogin(String email,String password)
        {
            if (!_userServices.isCheckEmail(email))
            {
                return BadRequest("Email not found");
            }
            if (_userServices.isCheckEmail(email) && _userServices.isCheckPassword(password))
            {
                return BadRequest("Invalid password");
            }
             _userServices.UsersLogin(email, password);
            return Created("", new { status = 200, message = "Login successful" });
        }
    }
}
 