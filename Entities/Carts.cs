using System.ComponentModel.DataAnnotations.Schema;

namespace backTOT.Entitys
{
    public class Carts
    {
        public Guid Id { get; set; }

        public Guid Users_id { get; set; }

        public Guid Course_id { get; set; }

        [ForeignKey("Users_id")]
        public Users users { get; set; }

        [ForeignKey("Course_id")]
        public Courses course { get; set; }
    }
}
