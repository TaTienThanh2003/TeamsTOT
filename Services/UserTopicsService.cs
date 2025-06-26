using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;

namespace backTOT.Services
{
    public class UserTopicsService : IUserTopicsService
    {
        private DataContext _context;
        public UserTopicsService(DataContext context)
        {
            _context = context;
        }

        public bool AddUserTopics(UserTopics userTopics)
        {
            _context.UserTopics.Add(userTopics);
            return Save();
        }

        public ICollection<UserTopics> GetUserTopics()
        {
            return _context.UserTopics.OrderBy(ut => ut.TopicId).ToList();
        }

        public ICollection<UserTopics> GetUserTopicsByStudentId(int studentId)
        {
            return _context.UserTopics.Where(ut => ut.UserId == studentId).ToList();
        }
        public bool UpdateIsComplete(int studentId, int topicId, bool isComplete)
        {
            var userTopic = _context.UserTopics
                .FirstOrDefault(ut => ut.UserId == studentId && ut.TopicId == topicId);

            if (userTopic == null)
                return false;

            userTopic.IsComplete = isComplete;
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
