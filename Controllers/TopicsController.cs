using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/topics")]
    [ApiController]
    public class TopicsController : Controller
    {
        private ITopicsService _topicsService;
        private IMapper _mapper;
        public TopicsController(ITopicsService topicsService, IMapper mapper)
        {
            _topicsService = topicsService;
            _mapper = mapper;
        }
        // getAll
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Topics>))]
        [ProducesResponseType(404)]
        public IActionResult GetAllCourses()
        {
            var topics = _topicsService.GetTopics();
            if (topics == null)
            {
                return NotFound(new { status = 404, message = "No topics found" });
            }
            var topicDto = _mapper.Map<List<TopicUserDtoLean>>(topics);
            return Ok(new { status = 200, message = "Success", data = topicDto });
        }

    }
}
