using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/lessonNotes")]
    [ApiController]
    public class LessonNotesController : Controller
    {
        private ILesson_notes _lesson_notes;
        private IMapper _mapper;
        public LessonNotesController(ILesson_notes lesson_notes, IMapper mapper)
        {
            _lesson_notes = lesson_notes;
            _mapper = mapper;
        }
        // getLessonNotesByUser
        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Lesson_notesDto>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetLesson_NotesByUser(int userId)
        {
            var lesson_Notes = _lesson_notes.GetLesson_NotesByUser(userId);
            var lessonNoteDto = _mapper.Map<List<Lesson_notesDto>>(lesson_Notes);
            if (lessonNoteDto == null)
            {
                return NotFound(new { status = 404, message = "lessonNote empty" });
            }
            return Ok(new { status = 200, message = "Success", data = lessonNoteDto });
        }
        // getLessonNotesByUser
        [HttpGet("lessonNoteByUser")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Lesson_notesDto>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetLesson_NotesByUserLesson(int userId, int lessonId)
        {
            var lesson_Notes = _lesson_notes.GetLesson_NotesByUserLesson(userId,lessonId);
            var lessonNoteDto = _mapper.Map<List<Lesson_notesDto>>(lesson_Notes);
            if (lessonNoteDto == null)
            {
                return NotFound(new { status = 404, message = "lessonNote empty" });
            }
            return Ok(new { status = 200, message = "Success", data = lessonNoteDto });
        }
        [HttpPost("addLessonNote")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult addLessonNotes([FromBody] Lesson_notesDto lessonNoteDto)
        {
            if (lessonNoteDto == null)
            {
                return BadRequest(new { status = 400, message = "Invalid lessonNote data" });
            }
            var lessonNote = _mapper.Map<Lesson_notes>(lessonNoteDto);
            var result = _lesson_notes.addLessonNotes(lessonNote);
            if (result == null)
            {
                return StatusCode(500, new { status = 500, message = "An error occurred while creating lessonNote" });
            }
            return Created("", new { status = 201, message = "Add Successfully", lessonNote = lessonNoteDto });
        }
    }
}
