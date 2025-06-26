using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/usertopics")]
    [ApiController]
    public class UserTopicsController : Controller
    {
        private IUserTopicsService _userTopicsService;
        private IMapper _mapper;
        public UserTopicsController(IUserTopicsService userTopicsService, IMapper mapper)
        {
            _userTopicsService = userTopicsService;
            _mapper = mapper;
        }
        // getAll
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserTopics>))]
        [ProducesResponseType(404)]
        public IActionResult GetAllUserTopics()
        {
            var userTopics = _userTopicsService.GetUserTopics();
            if (userTopics == null)
            {
                return NotFound(new { status = 404, message = "No usertopics found" });
            }
            return Ok(new { status = 200, message = "Success", data = userTopics });
        }
        // getId
        [HttpGet("{studentId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserTopics>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetUserTopicsByStudentId(int studentId)
        {
            var userTopics = _userTopicsService.GetUserTopicsByStudentId(studentId);
            if (userTopics == null)
            {
                return NotFound(new { status = 404, message = "userTopics not found" });
            }
            return Ok(new { status = 200, message = "Success", data = userTopics });
        }
        [HttpPost("addUserTopics")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult AddUserTopics([FromBody] AddUserTopicDto userTopicsdto)
        {
            if (userTopicsdto == null)
            {
                return BadRequest(new { status = 400, message = "Invalid UserTopics data" });
            }
            var userTopics = _mapper.Map<UserTopics>(userTopicsdto);
            var result = _userTopicsService.AddUserTopics(userTopics);
            if (result == null)
            {
                return StatusCode(500, new { status = 500, message = "An error occurred while creating UserTopics" });
            }
            return Created("", new { status = 201, message = "Add Successfully", userTopics = result });
        }
        [HttpPut("updateIsComplete")]
        public IActionResult UpdateIsComplete([FromBody] UpdateUserTopicCompleteDto dto)
        {
            if (dto == null)
                return BadRequest(new { status = 400, message = "Invalid data" });

            var result = _userTopicsService.UpdateIsComplete(dto.UserId, dto.TopicId, dto.IsComplete);
            if (!result)
                return NotFound(new { status = 404, message = "UserTopic not found or update failed" });

            return Ok(new { status = 200, message = "IsComplete updated successfully" });
        }
    }
}
