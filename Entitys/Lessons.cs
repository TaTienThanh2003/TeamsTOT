using System.ComponentModel.DataAnnotations;
using backTOT.Dto;

namespace backTOT.Entitys
{
    public class Lessons
    {
        public int Id { get; set; }
        public int Section_id { get; set; }
        public string TitleVI { get; set; }
        public string TitleEN { get; set; }
        public string? DesVI { get; set; }
        public string? DesEN { get; set; }
        public string? Video_url { get; set; }
        public Boolean? Completed { get; set; } = false;
        public int Position { get; set; } = 0;
        // relation
        public ICollection<Lesson_notes> Lesson_notes { get; set; } = new List<Lesson_notes>();
        public ICollection<Comments> Comments { get; set; } = new List<Comments>();
        public ICollection<UserLesson> UserLessons { get; set; }

        public Sections sections { get; set; }
    }
}
