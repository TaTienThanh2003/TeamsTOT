namespace backTOT.Entitys
{
    public class CourseOff
    {
        public int Id { get; set; }
        public int course_id { get; set; }
        public string Time { get; set; }
        public string Schedule { get; set;}
        public DateOnly Date { get; set; }
        public bool Status { get; set; }

        // ralation
        public Courses courses { get; set; }
    }
}
