using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;

namespace backTOT.Services
{
    public class TopicsService : ITopicsService
    {
        private DataContext _context;
        public TopicsService(DataContext context)
        {
            _context = context;
        }
        public ICollection<Topics> GetTopics()
        {
            return _context.Topics.OrderBy(t => t.Id).ToList();
        }
    }
}
