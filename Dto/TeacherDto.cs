using System.ComponentModel.DataAnnotations;

namespace backTOT.Dto
{
    public class TeacherDto
    {
        public String? FullName { get; set; }
        [MaxLength(50)]
        public String Email { get; set; }
        [MaxLength(12)]
        public String? Phone { get; set; }
        public string? Image { get; set; } = "img/face.jpg";
        public String? Des { get; set; }
    }
}
