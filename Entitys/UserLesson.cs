using System.ComponentModel.DataAnnotations.Schema;

namespace backTOT.Entitys
{
    public class UserLesson
    {
        public int Id { get; set; }
        public int Student_id { get; set; }
        [ForeignKey(nameof(Student_id))]
        public virtual Users Users { get; set; }
        public int LessonsId { get; set; }
        [ForeignKey(nameof(LessonsId))]
        public virtual Lessons Lessons { get; set; }
        public bool IsComplete { get; set; } 
    }
}
