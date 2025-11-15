using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IVocabularysService
    {
        ICollection<Vocabularys> getVocabularyByTopic(Guid topicId);
    }
}
