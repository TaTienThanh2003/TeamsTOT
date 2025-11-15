using System.ComponentModel.DataAnnotations;

namespace backTOT.Entitys
{
    public class Reviews
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public String Content { get; set; }

        [Range(1, 5, ErrorMessage = "Số sao phải từ 1 đến 5")]
        public int? Star { get; set; }
        //relation
        public Users users { get; set; }
        public Courses courses { get; set; }
    }
}
