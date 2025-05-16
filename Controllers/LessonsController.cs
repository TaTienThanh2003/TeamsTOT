
using AutoMapper;
using backTOT.Dto;
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
        // deleteLession
        [HttpDelete("{id}")]
        public IActionResult DeleteLesson(int id)
        {
            var ischeck = _lessonsServices.ischeckId(id);
            if (!ischeck) return NotFound("Id không tồn tại");
            _lessonsServices.deleteLesson(id);
            return Ok(new { status = 200, message = "delete Success" });
        }
        [HttpPut("api/lessons/{id}")]
        public IActionResult UpdateLesson(int id, [FromBody] LessonsDto lessonDto)
        {
            var lesson = _lessonsServices.GetLessonsById(id);
            if (lesson == null)
                return NotFound("Not Found lesson");
            var lessons = _mapper.Map<Lessons>(lessonDto);
            lessons.Id = id;
            _lessonsServices.updateLesson(lessons);
            return Ok(new { status = 200, message = "Success", data = lessonDto });
        }
        [HttpPost("addLesson")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult addLesson([FromBody] LessonsDto lessonDto)
        {
            if (lessonDto == null)
            {
                return BadRequest(new { status = 400, message = "Invalid lesson data" });
            }
            var ischeckTitleVI = _lessonsServices.ischeckName(lessonDto.TitleVI);
            if (ischeckTitleVI)
            {
                return Conflict(new { status = 409, message = "Lesson already exists" });
            }
            var lessonAdd = _mapper.Map<Lessons>(lessonDto);
            if (lessonAdd == null)
            {
                return StatusCode(500, new { status = 500, message = "An error occurred while creating lesson" });
            }
            _lessonsServices.addLesson(lessonAdd);
            return Created("", new { status = 201, message = "Add Successfully", courseAdd = lessonDto });
        }
    }
}
