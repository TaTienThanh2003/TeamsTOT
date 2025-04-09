namespace backTOT.Entitys
{
    public class Enrollments
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Courses_id { get; set; }
        public DateOnly Start_date { get; set; }
        public DateOnly End_date { get; set; }
        public DateOnly created_ad { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        // quan hệ
        public Users user { get; set; }
        public Courses courses { get; set; }
    }
}
