using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using backTOT.Entitys;

namespace backTOT.Dto
{
    public class CoursesActionDto
    {
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
