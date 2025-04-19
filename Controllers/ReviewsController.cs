using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private IReviewsService _reviewsService;
        private IMapper _mapper;
        public ReviewsController(IReviewsService reviewsService, IMapper mapper)
        {
            _reviewsService = reviewsService;
            _mapper = mapper;
        }
        // getId
        [HttpGet("{courseId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviews>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsByCourse(int courseId)
        {
            var review = _reviewsService.GetReviewsByCourse(courseId); 
            if (review == null)
            {
                return NotFound(new { status = 404, message = "Review not found" });
            }
            var reviewDto = _mapper.Map<List<ReviewsDto>>(review);
            return Ok(new { status = 200, message = "Success", data = reviewDto });
        }
        [HttpPost("addReview")]
        public IActionResult CreateReview([FromBody] ReviewsDto reviewsDto)
        {

            // Kiểm tra xem người dùng đã học khóa học này chưa
            if (!_reviewsService.HasUserEnrolledInCourse(reviewsDto.UserId, reviewsDto.CourseId))
            {
                return BadRequest(new { message = "Bạn phải học khóa học này trước khi đánh giá." });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = _mapper.Map<Reviews>(reviewsDto);

            // Thêm đánh giá vào cơ sở dữ liệu
            if (_reviewsService.AddReview(review))
            {
                return Ok(new { message = "Review sent" });
            }

            return BadRequest(new { message = "Đã có lỗi xảy ra." });
        }
    }
}
