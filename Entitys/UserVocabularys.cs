namespace backTOT.Entitys
{
    public class UserVocabularys
    {
        public int Id { get; set; }
        public int Student_id { get; set; }
        public int VocabularyId { get; set; }

        // relation
        public bool IsActive { get; set; } = true;
    }
}
