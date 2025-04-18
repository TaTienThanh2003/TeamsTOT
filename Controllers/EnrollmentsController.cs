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
        // getId
        [HttpGet("{studentId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Enrollments>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetUserById(int studentId)
        {
            var enrollment = _iEnrollmentService.GetEnrollmentsByStudentId(studentId);
            if (enrollment == null)
            {
                return NotFound(new { status = 404, message = "Enrollment not found" });
            }
            return Ok(new { status = 200, message = "Success", data = enrollment });
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
