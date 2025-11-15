using backTOT.Entitys;

namespace backTOT.Dto
{
    public class Lesson_notesDto
    {
        public Guid Lesson_id { get; set; }
        public Guid User_id { get; set; }
        public string Text { get; set; }
        public TimeSpan Video_time { get; set; }
    }
}
