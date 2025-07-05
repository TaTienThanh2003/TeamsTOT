using AutoMapper;
using backTOT.Data;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backTOT.Controllers
{
    [Route("api/schedules")]
    [ApiController]
    public class SchedulesController : Controller
    {
        private readonly IScheduleServices _scheduleService;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public SchedulesController(IScheduleServices scheduleService, IMapper mapper,DataContext context)
        {
            _context = context;
            _scheduleService = scheduleService;
            _mapper = mapper;
        }
        [HttpGet("user/{userId}")]
        public IActionResult GetByUser(int userId)
        {
            var schedules = _scheduleService.GetSchedulesWithUser(userId);

            if (schedules == null || !schedules.Any())
            {
                return NotFound(new
                {
                    status = 404,
                    message = "No schedule found for this user."
                });
            }

            return Ok(new
            {
                status = 200,
                message = "Schedule list retrieved successfully.",
                data = schedules
            });
        }

        [HttpGet("user/{userId}/course/{courseId}")]
        public IActionResult GetByUserCourse(int userId, int courseId)
        {
            var schedule = _scheduleService.GetSchedulesByUserCourse(userId, courseId);

            if (schedule == null)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "No schedule found for this user and course."
                });
            }

            return Ok(new
            {
                status = 200,
                message = "Schedule retrieved successfully.",
                data = schedule
            });
        }

        [HttpPost]
        public IActionResult AddSchedule([FromBody] AddScheduleDTO schedulesDto)
        {
            if (schedulesDto == null || string.IsNullOrEmpty(schedulesDto.DayOfWeek))
            {
                return BadRequest(new
                {
                    status = 400,
                    message = "Invalid input data."
                });
            }
            if (_scheduleService.isCheckScheduleExits(schedulesDto.StudentId, schedulesDto.Courses_id))
            {
                var removed = _scheduleService.RemoveSchedules(schedulesDto.StudentId, schedulesDto.Courses_id);

                if (!removed)
                {
                    return StatusCode(500, new
                    {
                        status = 500,
                        message = "Failed to remove existing schedule."
                    });
                }
            }
            var course = _context.Courses.FirstOrDefault(c => c.Id == schedulesDto.Courses_id);
            var schedule = new Schedules
                {
                    StudentId = schedulesDto.StudentId,
                    Courses_id = schedulesDto.Courses_id,
                    DayOfWeek = schedulesDto.DayOfWeek,
                    TimeLearn = schedulesDto.TimeLearn,
                    Start_date = DateOnly.FromDateTime(DateTime.Now),
                    CreatedAt = DateTime.Now,

                    Courses = course
                };
            if (course == null)
            {
                return NotFound(new
                {
                    status = 404,
                    message = $"Không tìm thấy Course với ID = {schedulesDto.Courses_id}"
                });
            }

            schedule.CalculateEndDate();
                _scheduleService.AddSchedules(schedule); 
            return Ok(new
            {
                status = 200,
                message = "Schedule added successfully."
            });
        }

        [HttpDelete("user/{userId}/course/{courseId}")]
        public IActionResult Delete(int userId, int courseId)
        {
            var removed = _scheduleService.RemoveSchedules(userId, courseId);

            if (!removed)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "Schedule not found for deletion."
                });
            }

            return Ok(new
            {
                status = 200,
                message = "Schedule deleted successfully."
            });
        }
    }
}
