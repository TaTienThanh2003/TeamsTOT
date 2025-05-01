using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : Controller
    {
        private ICommentsService _iCommentsService;
        private IMapper _mapper;
        public CommentsController(ICommentsService iCommentsService, IMapper mapper)
        {
            _iCommentsService = iCommentsService;
            _mapper = mapper;
        }
        // get GetCommentsByLessonId
        [HttpGet("{lessonId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Comments>))]
        [ProducesResponseType(404)]
        public IActionResult GetCommentsByLessonId(int lessonId)
        {
            var comments = _iCommentsService.GetCommentsByLessonId(lessonId);
            if (comments == null)
            {
                return NotFound(new { status = 404, message = "No comments found" });
            }
            return Ok(new { status = 200, message = "Success", data = comments });
        }
        [HttpPost("addComment")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult AddComments([FromBody] CommentDto commentDto)
        {
            if (commentDto == null)
            {
                return BadRequest(new { status = 400, message = "Invalid comment data" });
            }
            var comments = _mapper.Map<Comments>(commentDto);
            var result = _iCommentsService.AddComments(comments);
            if (!result)
            {
                return StatusCode(500, new { status = 500, message = "An error occurred while creating comment" });
            }
            return Created("", new { status = 201, message = "Add Successfully", comments = commentDto });
        }
    }
}
