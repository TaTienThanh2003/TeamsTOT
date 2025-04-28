using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : Controller
    {
        private IEnrollmentService _iEnrollmentService;
        private IMapper _mapper;
        public EnrollmentsController(IEnrollmentService iEnrollmentService, IMapper mapper)
        {
            _iEnrollmentService = iEnrollmentService;
            _mapper = mapper;
        }
        // getEnrollmentByUserId
        [HttpGet("getEnrollmentByUserId/{studentId}")]
        public IActionResult getEnrollmentByUserId(int studentId)
        {
            var enrollment = _iEnrollmentService.GetEnrollmentByUserId(studentId);
            // Kiểm tra nếu không có khóa học cho user
            if (enrollment == null )
            {
                return NotFound(new
                { status = 404,message = "Không tìm thấy khóa học cho người dùng này"});
            }

            var enrollmentDto = _mapper.Map<List<EnrollmentDtoResponse>>(enrollment);
            return Ok(new
            {
                status = 200,
                message = "Lấy danh sách khóa học thành công",
                data = enrollmentDto
            });
        }
        [HttpPost("addEnrollment")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult addEntrollment([FromBody] EnrollmentDto enrollmentDto)
        {
            if (enrollmentDto == null)
            {
                return BadRequest(new { status = 400, message = "Invalid enrollment data" });
            }
            var enrollment = _mapper.Map<Enrollments>(enrollmentDto);

            var success = _iEnrollmentService.AddEnrollment(enrollment);
            if (!success) return BadRequest("Course not found or add failed");

            return Ok("Enrollment added successfully");
        }
    }
}
