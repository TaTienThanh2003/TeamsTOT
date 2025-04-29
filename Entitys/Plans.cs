using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backTOT.Entitys
{
    public class Plans
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string TitleVI { get; set; }
        [MaxLength(255)]
        public string TitleEN { get; set; }
        public string? DesVI { get; set; }
        public string? DesEN { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public int Price { get; set; }
        public int TrialPeriodDays { get; set; } = 30;
        // relation
        public ICollection<User_plans> User_Plans { get; set; } = new List<User_plans>();
    }
}
