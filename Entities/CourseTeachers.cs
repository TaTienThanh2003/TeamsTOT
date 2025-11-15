namespace backTOT.Entitys
{
    public class CourseTeachers
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Courses Course { get; set; }

        public Guid TeacherId { get; set; }
        public Users Teacher { get; set; }
    }
}
