using System.ComponentModel.DataAnnotations;

namespace backTOT.Entitys
{
    public class Topics
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Des { get; set; }

        // relation
        public ICollection<Flashcards> Flashcards { get; set; } = new List<Flashcards>();
    }
}
