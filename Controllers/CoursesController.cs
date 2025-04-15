using AutoMapper;
using backTOT.Entitys;
using backTOT.Interface;
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
