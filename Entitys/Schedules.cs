using System.ComponentModel.DataAnnotations;

namespace backTOT.Entitys
{
    public class Schedules
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int Courses_id { get; set; }
        [Required]
        public string DayOfWeek { get; set; }
        public string TimeLearn { get; set; }
        public DateOnly Start_date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly? End_date { get; set; }
        public DateTime CreatedAt { get; set; }

        // Nếu bạn có navigation đến Student
        public virtual Users Users { get; set; }
        public virtual Courses Courses { get; set; }
        public void CalculateEndDate()
        {
            // Ensure we have the courses data loaded
            if (Courses != null)
            {
                // Add CountDay to Start_date to calculate End_date
                End_date = Start_date.AddDays(Courses.CountDay);
            }
        }
    }
}
