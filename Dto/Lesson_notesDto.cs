using backTOT.Entitys;

namespace backTOT.Dto
{
    public class Lesson_notesDto
    {
        public int Lesson_id { get; set; }
        public int User_id { get; set; }
        public string Text { get; set; }
        public TimeSpan Video_time { get; set; }
    }
}
