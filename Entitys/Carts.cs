using System.ComponentModel.DataAnnotations.Schema;

namespace backTOT.Entitys
{
    public class Carts
    {
        public int Id { get; set; }
        public int Users_id { get; set; }
        public int Course_id { get; set; }

    }
}
