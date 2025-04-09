using AutoMapper;
using backTOT.Entitys;
using backTOT.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    public class CoursesControllers
    {
        [Route("api/courses")]
        [ApiController]
        public class UserControlles : Controller
        {
            private ICoursesService _coursesService;
            private IMapper _mapper;
            public UserControlles(ICoursesService coursesService, IMapper mapper)
            {
                _coursesService = coursesService;
                _mapper = mapper;
            }
            // getAll
            [HttpGet]
            [ProducesResponseType(200, Type = typeof(IEnumerable<Courses>))]
            [ProducesResponseType(404)]
            public IActionResult GetAllUsers()
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
}
