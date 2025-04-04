using System.Text.Json.Serialization;

namespace backTOT.Dto
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        USER, ADMIN, TEACHER
    }

    public class UserDto
    {
        public String FullName { get; set; }
        public String Rmail { get; set; }
        public String Password { get; set; }
        public String Phone { get; set; }
        public Role Role { get; set; }

        public DateTime created_ad { get; set; } = DateTime.Now;
    }
}
