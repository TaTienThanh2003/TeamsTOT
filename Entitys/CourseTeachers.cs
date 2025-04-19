namespace backTOT.Entitys
{
    public class CourseTeachers
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Courses Course { get; set; }

        public int TeacherId { get; set; }
        public Users Teacher { get; set; }
    }
}
