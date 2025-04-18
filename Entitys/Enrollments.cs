namespace backTOT.Entitys
{
    public class Enrollments
    {
        public int Id { get; set; }
        public int Student_id { get; set; }
        public int Courses_id { get; set; }
        public DateOnly Start_date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly? End_date { get; set; }
        public DateOnly created_ad { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        // relation
        public Users user { get; set; }
        public Courses courses { get; set; }
        // Method to calculate End_date based on Courses CountDay
        public void CalculateEndDate()
        {
            // Ensure we have the courses data loaded
            if (courses != null)
            {
                // Add CountDay to Start_date to calculate End_date
                End_date = Start_date.AddDays(courses.CountDay);
            }
        }
    }
}