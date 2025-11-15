namespace backTOT.Entitys
{
    public class Lesson_notes
    {
        public Guid Id { get; set; }
        public Guid Lesson_id { get; set; }
        public Guid User_id { get; set; }
        public string Text { get; set; }
        public TimeSpan Video_time { get; set; }
        public DateOnly created_ad { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        //relation
        public Lessons lessons { get; set; }
        public Users users { get; set; }
    }
}
