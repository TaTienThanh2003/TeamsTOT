using AutoMapper;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/catalogs")]
    [ApiController]
    public class CatalogsController : Controller
    {
        private ICatalogsService _catalogsService;
        private IMapper _mapper;
        public CatalogsController(ICatalogsService catalogsService, IMapper mapper)
        {
            _catalogsService = catalogsService;
            _mapper = mapper;
        }
        // getAll
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Courses>))]
        [ProducesResponseType(404)]
        public IActionResult GetAllCourses()
        {
            var catalog = _catalogsService.GetCatalogs();
            if (catalog == null)
            {
                return NotFound(new { status = 404, message = "No catalog found" });
            }
            return Ok(new { status = 200, message = "Success", data = catalog });
        }
    }
}
