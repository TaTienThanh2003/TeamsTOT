using System.ComponentModel.DataAnnotations;

namespace backTOT.Entitys
{
    public class Vocabularys
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
        public string AudioUrl { get; set; }
        public int Level { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        // relation
        public Topics topics { get; set; }
        public ICollection<UserVocabularys> UserVocabularys { get; set; } = new List<UserVocabularys>();
    }
}
