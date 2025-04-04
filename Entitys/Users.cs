using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backTOT.Entitys
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        USER,ADMIN, TEACHER
    }

    public class Users
    {
        public int Id { get; set; }
        public String FullName  { get; set; }
        public String Rmail { get; set; }
        public String Password { get; set; }
        public String Phone { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public Role Role { get; set; }

        public DateTime created_ad { get; set; } = DateTime.Now;
    }
}
