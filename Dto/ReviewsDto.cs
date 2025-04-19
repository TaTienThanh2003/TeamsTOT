using System.ComponentModel.DataAnnotations;

namespace backTOT.Dto
{
    public class ReviewsDto
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public string Content { get; set; }

        [Range(1, 5, ErrorMessage = "Số sao phải từ 1 đến 5")]
        public int Star { get; set; }
    }
}
