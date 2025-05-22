using AutoMapper;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/flashcards")]
    [ApiController]
    public class FlashcardsController : Controller
    {
        private IFlashcardsService _flashcardsService;
        private IMapper _mapper;
        public FlashcardsController(IFlashcardsService flashcardsService, IMapper mapper)
        {
            _flashcardsService = flashcardsService;
            _mapper = mapper;
        }
        // getflashcardsBytopicId
        [HttpGet("{topicId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Flashcards>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetFlashcardsBy(int topicId)
        {
            var flashcards = _flashcardsService.GetFlashcardsBy(topicId);
            if (flashcards == null)
            {
                return NotFound(new { status = 404, message = "flashcards not found" });
            }
            return Ok(new { status = 200, message = "Success", data = flashcards });
        }
    }
}
