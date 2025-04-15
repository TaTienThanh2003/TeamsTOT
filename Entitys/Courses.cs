using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backTOT.Entitys
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Mode
    {
        ONLINE, OFFLINE
    }
    public class Courses
    {
        public  int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public string? Description { get; set; }
        public int Teacher_id { get; set; }
        public int CountDay { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; }

        public Mode? Mode { get; set; }
        public string Img { get; set; }
        // relation
        public ICollection<Enrollments> Enrollments { get; set; } = new List<Enrollments>();
        public ICollection<Lessons> Lessons { get; set; } = new List<Lessons>();
        public ICollection<Schedules> Schedules { get; set; } = new List<Schedules>();
        public ICollection<Scores> Scores { get; set; } = new List<Scores>();
        public Users user { get; set; }
    }
}
