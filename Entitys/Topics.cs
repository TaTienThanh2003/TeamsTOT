using System.ComponentModel.DataAnnotations;

namespace backTOT.Entitys
{
    public class Topics
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int WordCount { get; set; }
        public string ImageUrl { get; set; }
        public string? Des { get; set; }
        public int? UsersCreated_id { get; set; } 

        // relation
        public Users UserCreated { get; set; }
        public ICollection<Users> Users { get; set; } = new List<Users>();
        public ICollection<Vocabularys> Vocabularys { get; set; } = new List<Vocabularys>();
    }
}
