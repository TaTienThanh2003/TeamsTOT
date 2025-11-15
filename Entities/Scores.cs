using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backTOT.Entitys
{
    public class Scores
    {
        public Guid Id { get; set; }
        public Guid Student_id { get; set; }
        public Guid Courses_id { get; set; }
        [MaxLength(255)]
        public String? Test_name { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Score { get; set; }
        public DateOnly Date_taken { get; set; }

        // relation
        public Users user { get; set; }
        public Courses courses { get; set; }

    }
}
