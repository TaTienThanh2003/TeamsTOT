using System.ComponentModel.DataAnnotations;

namespace backTOT.Entitys
{
    public class Lessons
    {
        public int Id { get; set; }
        public int Courses_id { get; set; }
        [MaxLength(255)]
        public String? Title { get; set; }
        public String? Content { get; set; }
        public String? Video_url { get; set; }

        // relation
        public ICollection<Schedules> Schedules { get; set; } = new List<Schedules>();
        public Courses courses { get; set; }
    }
}
