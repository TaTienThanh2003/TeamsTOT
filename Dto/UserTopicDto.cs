using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backTOT.Dto
{
    public class UserTopicDto
    {
        public String? FullName { get; set; }
        [MaxLength(50)]
        public String Email { get; set; }
        [MaxLength(12)]
        public String? Phone { get; set; }
        public string? Image { get; set; } = "img/face.jpg";
    }
}
