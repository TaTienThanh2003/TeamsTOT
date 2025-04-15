using System.ComponentModel.DataAnnotations.Schema;

namespace backTOT.Entitys
{
    public class Carts
    {
        public int Id { get; set; }

        public int Users_id { get; set; }

        public int Course_id { get; set; }

        [ForeignKey("Users_id")]
        public Users users { get; set; }

        [ForeignKey("Course_id")]
        public Courses course { get; set; }
    }
}
