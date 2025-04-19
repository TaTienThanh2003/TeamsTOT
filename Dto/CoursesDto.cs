using backTOT.Entitys;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backTOT.Dto
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Mode
    {
        ONLINE, OFFLINE
    }
    public class CoursesDto
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public string? Description { get; set; }
        public int CountDay { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; }

        public Mode? Mode { get; set; }
        public string Img { get; set; }
    }
}
