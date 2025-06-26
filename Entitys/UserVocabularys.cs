using System.ComponentModel.DataAnnotations.Schema;

namespace backTOT.Entitys
{
    public class UserVocabularys
    {
        public int Id { get; set; }

        public int Student_id { get; set; }
        [ForeignKey(nameof(Student_id))]
        public virtual Users Users { get; set; }

        public int VocabularyId { get; set; }
        [ForeignKey(nameof(VocabularyId))]
        public virtual Vocabularys Vocabularys { get; set; }

        public int? TopicId { get; set; } = 0;
        [ForeignKey(nameof(TopicId))]
        public virtual Topics Topics { get; set; } 

        public bool IsActive { get; set; } 
    }

}
