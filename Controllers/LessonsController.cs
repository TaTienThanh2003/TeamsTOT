
using AutoMapper;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/lessons")]
    [ApiController]
    public class LessonsController : Controller
    {
        private ILessonsService _lessonsServices;
        private IMapper _mapper;

        public LessonsController(ILessonsService lessonsServices, IMapper mapper)
        {
            _lessonsServices = lessonsServices;
            _mapper = mapper;
        }
        // getLessonsByCourseID
        [HttpGet("{courseId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Lessons>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult getLessonByCourses(int courseId)
        {
            var lessons = _lessonsServices.getLessonByCourses(courseId);
            if (lessons == null)
            {
                return NotFound(new { status = 404, message = "lessons not found" });
            }
            return Ok(new { status = 200, message = "Success", data = lessons });
        }
    }
}
