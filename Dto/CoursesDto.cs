using backTOT.Entitys;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backTOT.Dto
{
    public class CoursesDto
    {
        public Guid Id { get; set; }
        public string TitleVI { get; set; }
        public string TitleEN { get; set; }
        public string? DesVI { get; set; }
        public string? DesEN { get; set; }
        public int CountDay { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; }

        public Mode? Mode { get; set; }
        public string Img { get; set; }
    }
}
