using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IFlashcardsService
    {
        ICollection<Flashcards> GetFlashcardsBy(int topicId);
    }
}
