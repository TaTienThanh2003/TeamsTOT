using AutoMapper;
using backTOT.Dto;
using backTOT.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CourseTeachersController:Controller
    {
        private ICourseTeachersService _iCourseTeachersService;
        private IMapper _mapper;
        public CourseTeachersController(ICourseTeachersService iCourseTeachersService, IMapper mapper)
        {
            _iCourseTeachersService = iCourseTeachersService;
            _mapper = mapper;
        }
        [HttpGet("GetTeacherByCourseId/{courseId}")]
        public IActionResult GetTeacherByCourseId(int courseId)
        {
            var teachers = _iCourseTeachersService.GetTeacherByCourseId(courseId);
            if (teachers == null)
                return NotFound(new { status = 404, message = "Không tìm thấy giáo viên nào" });

            var teacherDtos = _mapper.Map<List<TeacherDto>>(teachers); 
            return Ok(new { status = 200, message = "Successfully", data = teacherDtos });
        }

    }
}
