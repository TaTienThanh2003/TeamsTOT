using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;

namespace backTOT.Services
{
    public class VocabularysService : IVocabularysService
    {
        private DataContext _context;
        public VocabularysService(DataContext context)
        {
            _context = context;
        }

        public ICollection<Vocabularys> getVocabularyByTopic(int topicId)
        {
            return _context.Vocabularys.Where(v =>v.Topics_id == topicId).ToList();
        }
    }
}
