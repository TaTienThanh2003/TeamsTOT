using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;
using Microsoft.EntityFrameworkCore;

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
            var topics = _context.Topics
                .Include(t => t.UserTopics)
                    .ThenInclude(ut => ut.Users)
                    .Include(v => v.UserVocabularys)
                    .ThenInclude(uv => uv.Vocabularys)
                .OrderBy(t => t.Id)
                .ToList();

            // Gán thủ công danh sách Users cho từng Topic
            foreach (var topic in topics)
            {
                topic.Users = topic.UserTopics.Select(ut => ut.Users).ToList();
                // gán thêm Vocabularys
                topic.Vocabularys = topic.UserVocabularys.Select(uv => uv.Vocabularys).ToList();
            }

            return topics;
        }

    }
}
