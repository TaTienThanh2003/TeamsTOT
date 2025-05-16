using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/sections")]
    [ApiController]
    public class SectionsController : Controller
    {
        private ISectionsService _sectionsService;
        private IMapper _mapper;

        public SectionsController(ISectionsService sectionsService, IMapper mapper)
        {
            _sectionsService = sectionsService;
            _mapper = mapper;
        }
        // deleteSection
        [HttpDelete("{id}")]
        public IActionResult DeleteSection(int id)
        {
            var ischeck = _sectionsService.ischeckId(id);
            if (!ischeck) return NotFound("Id section không tồn tại");
            _sectionsService.deleteSection(id);
            return Ok(new { status = 200, message = "delete Success" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSection(int id, [FromBody] SectionsDto sectionsDto)
        {
            var section = _sectionsService.GetSectionById(id);
            if (section == null)
                return NotFound("Not Found section");
            var sections = _mapper.Map<Sections>(sectionsDto);
            sections.Id = id;
            _sectionsService.updateSection(sections);
            return Ok(new { status = 200, message = "Success", data = sectionsDto });
        }
        [HttpPost("addSection")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult addSection([FromBody] SectionsDto sectionsDto)
        {
            if (sectionsDto == null)
            {
                return BadRequest(new { status = 400, message = "Invalid section data" });
            }
            var ischeckTitleVI = _sectionsService.ischeckName(sectionsDto.TitleVI);
            if (ischeckTitleVI)
            {
                return Conflict(new { status = 409, message = "section already exists" });
            }
            var sectionAdd = _mapper.Map<Sections>(sectionsDto);
            if (sectionAdd == null)
            {
                return StatusCode(500, new { status = 500, message = "An error occurred while creating section" });
            }
            _sectionsService.addSection(sectionAdd);
            return Created("", new { status = 201, message = "Add Successfully", courseAdd = sectionsDto });
        }
    }
}
