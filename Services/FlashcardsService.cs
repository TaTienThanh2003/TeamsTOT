using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;

namespace backTOT.Services
{
    public class FlashcardsService : IFlashcardsService
    {
        private DataContext _context;
        public FlashcardsService(DataContext context)
        {
            _context = context;
        }
        public ICollection<Flashcards> GetFlashcardsBy(int topicId)
        {
            return _context.Flashcards
                .Where(f => f.Topics_id == topicId)
                .ToList();
        }
    }
}
