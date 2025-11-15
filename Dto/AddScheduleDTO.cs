using backTOT.Entitys;
using System.ComponentModel.DataAnnotations;

namespace backTOT.Dto
{
    public class AddScheduleDTO
    {
        public Guid StudentId { get; set; }
        public Guid Courses_id { get; set; }
        [Required]
        public string DayOfWeek { get; set; }
        public string TimeLearn { get; set; }
    }
}
