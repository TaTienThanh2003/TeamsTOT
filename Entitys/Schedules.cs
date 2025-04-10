namespace backTOT.Entitys
{
    public class Schedules
    {
        public int Id { get; set; }
        public int Courses_id { get; set; }
        public int Lessons_id { get; set; }
        public DateOnly Class_time { get; set; }

        //relation
        public Courses courses { get; set; }
        public Lessons lessons { get; set; }
    }
}
