using AutoMapper;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Authorize]
    [Route("api/uservocabularys")]
    [ApiController]
    public class UserVocabularysController : Controller
    {
        private IUserVocabularysService _userVocabularysService;
        private IMapper _mapper;
        public UserVocabularysController(IUserVocabularysService userVocabularysService, IMapper mapper)
        {
            _userVocabularysService = userVocabularysService;
            _mapper = mapper;
        }
        [HttpGet("getUserVocabularys")]
        public IActionResult GetUserVocabularys([FromQuery] Guid studentId, [FromQuery] Guid topicId)
        {
            var data = _userVocabularysService.GetUserVocabularys(studentId, topicId);
            return Ok(new { status = 200, message = "Success", data });
        }
        [HttpPost("addUserVocabularys")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult AddUserVocabularys([FromBody] UserVocabularys userVocabularys)
        {
            if (userVocabularys == null)
            {
                return BadRequest(new { status = 400, message = "Invalid UserVocabularys data" });
            }
            var result = _userVocabularysService.AddUserVocabularys(userVocabularys);
            if (result == null)
            {
                return StatusCode(500, new { status = 500, message = "An error occurred while creating UserVocabularys" });
            }
            return Created("", new { status = 201, message = "Add Successfully", userVocabularys = result });
        }
    }
}
