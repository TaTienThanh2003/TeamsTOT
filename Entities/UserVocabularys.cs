using System.ComponentModel.DataAnnotations.Schema;

namespace backTOT.Entitys
{
    public class UserVocabularys
    {
        public Guid Id { get; set; }

        public Guid Student_id { get; set; }
        [ForeignKey(nameof(Student_id))]
        public virtual Users Users { get; set; }

        public Guid VocabularyId { get; set; }
        [ForeignKey(nameof(VocabularyId))]
        public virtual Vocabularys Vocabularys { get; set; }

        public Guid? TopicId { get; set; }
        [ForeignKey(nameof(TopicId))]
        public virtual Topics Topics { get; set; } 

        public bool IsActive { get; set; } 
    }

}
