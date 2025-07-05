using backTOT.Entitys;
using System.ComponentModel.DataAnnotations;

namespace backTOT.Dto
{
    public class AddScheduleDTO
    {
        public int StudentId { get; set; }
        public int Courses_id { get; set; }
        [Required]
        public string DayOfWeek { get; set; }
        public string TimeLearn { get; set; }
    }
}
