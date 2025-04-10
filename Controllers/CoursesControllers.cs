using AutoMapper;
using backTOT.Entitys;
using backTOT.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
        [Route("api/courses")]
        [ApiController]
        public class CoursesControllers : Controller
        {
            private ICoursesService _coursesService;
            private IMapper _mapper;
            public CoursesControllers(ICoursesService coursesService, IMapper mapper)
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
                    return BadRequest("No courses found");
                }
                return Ok(courses);
            }
        }
}
