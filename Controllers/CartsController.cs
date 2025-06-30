using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartsController : Controller
    {
        private ICartsService _cartsService;
        private IMapper _mapper;
        public CartsController(ICartsService cartsService, IMapper mapper)
        {
            _cartsService = cartsService;
            _mapper = mapper;
        }
        // getCartByUser
        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Courses>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetCartByUser(int userId)
        {
            var cart = _cartsService.GetCartByUser(userId);
            if (cart == null)
            {
                return NotFound(new { status = 404, message = "Cart empty" });
            }
            return Ok(new { status = 200, message = "Success", data = cart });
        }
        // deleteCartByCourse
        [HttpDelete("{courseId}/{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Carts>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteCartByCourse(int courseId, int userId)
        {
            if(courseId == null && userId == null) {
                return BadRequest(new { status = 400, message = "Invalid course or user" });
            }
            var cartDelete = _cartsService.DeleteCourseOnCart(courseId, userId);
            if (!cartDelete)
            {
                return NotFound(new { status = 404, message = "Cart not found" });
            }
            return Ok(new { status = 200, message = "Success"});
        }
        [HttpPost("addCourse")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult AddCourseOnCart([FromBody] CartsDto cartDto)
        {
            if (cartDto == null)
            {
                return BadRequest(new { status = 400, message = "Invalid cart data" });
            }
            // Kiểm tra đã tồn tại chưa
            if (_cartsService.CheckExistCart(cartDto.Users_id, cartDto.Course_id))
            {
                return Conflict(new { status = 409, message = "Enrollment already exists" });
            }
            var cartAdd = _mapper.Map<Carts>(cartDto);
            var result = _cartsService.AddCourseOnCart(cartAdd);
            if (result == null)
            {
                return StatusCode(500, new { status = 500, message = "An error occurred while creating cart" });
            }
            return Created("", new { status = 201, message = "Add Successfully", userAdd = result });
        }
    }
}
