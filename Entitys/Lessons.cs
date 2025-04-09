using System.ComponentModel.DataAnnotations;

namespace backTOT.Entitys
{
    public class Lessons
    {
        public int Id { get; set; }
        public int Courses_id { get; set; }
        [MaxLength(255)]
        public String Title { get; set; }
        public String Content { get; set; }
    }
}
