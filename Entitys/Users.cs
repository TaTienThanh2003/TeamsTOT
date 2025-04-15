using System.ComponentModel.DataAnnotations;
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

        [MaxLength(50)]
        public String? FullName  { get; set; }
        [MaxLength(50)]
        public String Email { get; set; }
        [MaxLength(50)]
        public String Password { get; set; }
        [MaxLength(12)]
        public String? Phone { get; set; }
        public string? Image { get; set; } = "img/face.jpg";
        public String? Des { get; set; }
        
        public Role Role { get; set; } = Role.USER;
        
        public DateOnly created_ad { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        // relation
        public ICollection<Enrollments> Enrollments { get; set; } = new List<Enrollments>();
        public ICollection<Courses> Courses { get; set; } = new List<Courses>();
        public ICollection<Scores> Scores { get; set; } = new List<Scores>();
        public ICollection<Carts> Carts { get; set; } = new List<Carts>();
    }
}
