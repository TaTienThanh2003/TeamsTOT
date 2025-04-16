using backTOT.Entitys;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backTOT.Dto
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        USER, ADMIN, TEACHER
    }
    public class UserLoginDto
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public String? FullName { get; set; }
        [MaxLength(50)]
        public String Email { get; set; }
        [MaxLength(12)]
        public String? Phone { get; set; }
        public string? Image { get; set; } 
        public String? Des { get; set; }

        public Role Role { get; set; }
    }
}
