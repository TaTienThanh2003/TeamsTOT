using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IUserTopicsService
    {
        ICollection<UserTopics> GetUserTopics();
        ICollection<UserTopics> GetUserTopicsByStudentId(Guid studentId);
        bool AddUserTopics(UserTopics userTopics);
        bool UpdateIsComplete(Guid studentId, Guid topicId, bool isComplete);
        bool Save();
    }
}
