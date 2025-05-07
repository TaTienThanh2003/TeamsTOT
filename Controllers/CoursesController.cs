using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : Controller
    {
        private ICoursesService _coursesService;
        private IMapper _mapper;
        public CoursesController(ICoursesService coursesService, IMapper mapper)
        {
            _coursesService = coursesService;
            _mapper = mapper;
        }
        // getAll
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Courses>))]
        [ProducesResponseType(404)]
        public IActionResult GetAllCourses()
        {
            var courses = _coursesService.GetCourses();
            if (courses == null)
            {
                return NotFound(new { status = 404, message = "No courses found" });
            }
            return Ok(new { status = 200, message = "Success", data = courses });
        }
        // getCourseById
        [HttpGet("api/courses/{id}")]
        public IActionResult UpdateCourse(int id)
        {
            var course  = _coursesService.GetCoursesById(id);
            if (course == null)
                return NotFound("Không tìm thấy khóa học");
            // Trả về JSON để frontend cập nhật lại bảng
            return Ok(course);
        }
        // deleteCourse
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var ischeck = _coursesService.ischeckId(id);
            if (ischeck) return NotFound("Id không tồn tại");
            _coursesService.deleteCourse(id);
            return Ok(new { status = 200, message = "delete Success" });
        }
        [HttpPut("api/courses/{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] CoursesActionDto courseDto)
        {
            var course = _coursesService.GetCoursesById(id);
            if (course == null)
                return NotFound("Không tìm thấy khóa học");
            var courses = _mapper.Map<Courses>(courseDto);
            var ischeck = _coursesService.updateCourse(courses);
            return Ok(new { status = 200, message = "Success", data = courseDto });
        }
        [HttpPost("addCourse")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult addCourse([FromBody] CoursesActionDto courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest(new { status = 400, message = "Invalid course data" });
            }
            var ischeckTitleVI = _coursesService.ischeckName(courseDto.TitleVI);
            if (ischeckTitleVI)
            {
                return Conflict(new { status = 409, message = "Course already exists" });
            }
            var courseAdd = _mapper.Map<Courses>(courseDto);
            if (courseAdd == null)
            {
                return StatusCode(500, new { status = 500, message = "An error occurred while creating course" });
            }
            _coursesService.addCourse(courseAdd);
            return Created("", new { status = 201, message = "Add Successfully", courseAdd = courseDto });
        }
        // getAllCourseByName
        [HttpGet("name")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Courses>))]
        [ProducesResponseType(404)]
        public IActionResult GetAllCoursesByName(string name)
        {
            var courses = _coursesService.GetCoursesByName(name);
            if (courses == null)
            {
                return NotFound(new { status = 404, message = "No courses found" });
            }
            return Ok(new { status = 200, message = "Success", data = courses });
        }
    }
}
