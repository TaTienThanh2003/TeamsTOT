using AutoMapper;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/vocabularies")]
    [ApiController]
    public class VocabularysController : Controller
    {
        private IVocabularysService _vocabularysService;
        private IMapper _mapper;
        public VocabularysController(IVocabularysService vocabularysService, IMapper mapper)
        {
            _vocabularysService = vocabularysService;
            _mapper = mapper;
        }
        // getVocabularyByTopicId
        [HttpGet("{topicId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Vocabularys>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult getVocabularyByTopic(int topicId)
        {
            var vocabylaries = _vocabularysService.getVocabularyByTopic(topicId);
            if (vocabylaries == null)
            {
                return NotFound(new { status = 404, message = "Vocabylaries empty" });
            }
            return Ok(new { status = 200, message = "Success", data = vocabylaries });
        }
    }
}
