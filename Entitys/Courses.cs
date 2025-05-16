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
        public int? CatalogId { get; set; }
        [MaxLength(255)]
        public string TitleVI { get; set; }
        [MaxLength(255)]
        public string TitleEN { get; set; }
        public string? DesVI { get; set; }
        public string? DesEN { get; set; }
        public int CountDay { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; }
        public Mode? Mode { get; set; }
        public string Img { get; set; }
        public int Num { get; set; }
        // relation
        public ICollection<Enrollments> Enrollments { get; set; } = new List<Enrollments>();
        public ICollection<Sections> Sections { get; set; } = new List<Sections>();
        public ICollection<Schedules> Schedules { get; set; } = new List<Schedules>();
        public ICollection<Scores> Scores { get; set; } = new List<Scores>();
        public ICollection<Carts> Carts { get; set; } = new List<Carts>();
        public ICollection<CourseTeachers> CourseTeachers { get; set; } = new List<CourseTeachers>();
        public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
        public CourseOff courseOff { get; set; }
        public Catalogs catalogs { get; set; }
    }
}
