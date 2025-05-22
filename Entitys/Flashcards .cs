using System.ComponentModel.DataAnnotations;

namespace backTOT.Entitys
{
    public class Flashcards
    {
        public int Id { get; set; }
        public int Topics_id { get; set; }
        [MaxLength(100)]
        public string Word { get; set; }
        [MaxLength(50)]
        public string WordType { get; set; }
        [MaxLength(100)]
        public string Phonetic { get; set; }
        public string DefVi { get; set; }
        public string ExampleEn { get; set; }
        public string ExampleVn { get; set; }
        public string Img { get; set; }

        // relation
        public Topics topics { get; set; }
    }
}
