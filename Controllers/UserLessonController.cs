using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/userlesson")]
    [ApiController]
    public class UserLessonController : Controller
    {
        private IUsersLessonService _usersLessonService;
        private IMapper _mapper;
        public UserLessonController(IUsersLessonService usersLessonService, IMapper mapper)
        {
            _usersLessonService = usersLessonService;
            _mapper = mapper;
        }
        // getId
        [HttpGet("{studentId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserLesson>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetUserLessonByStudentId(int studentId)
        {
            var userLesson = _usersLessonService.GetUserLesson(studentId);
            if (userLesson == null)
            {
                return NotFound(new { status = 404, message = "userlesson not found" });
            }
            return Ok(new { status = 200, message = "Success", data = userLesson });
        }
        [HttpPost("addUserLesson")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult AddUserLesson([FromBody] UserLessonCreateDto userLessondto)
        {
            if (userLessondto == null)
            {
                return BadRequest(new { status = 400, message = "Invalid UserLesson data" });
            }
            var userLesson = _mapper.Map<UserLesson>(userLessondto);
            userLesson.IsComplete = false;
            var result = _usersLessonService.AddUserLesson(userLesson);
            if (result == null)
            {
                return StatusCode(500, new { status = 500, message = "An error occurred while creating UserLesson" });
            }
            return Created("", new { status = 201, message = "Add Successfully", userLesson = result });
        }
    }
}
