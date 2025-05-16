using System.ComponentModel.DataAnnotations;

namespace backTOT.Entitys
{
    public class Catalogs
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public String Name { get; set; }
        public string? DesVI { get; set; }
        public string? DesEN { get; set; }

        //relation
        public ICollection<Courses> Courses { get; set; } = new List<Courses>();
    }
}
