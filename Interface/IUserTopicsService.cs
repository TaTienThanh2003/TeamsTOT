using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IUserTopicsService
    {
        ICollection<UserTopics> GetUserTopics();
        ICollection<UserTopics> GetUserTopicsByStudentId(int studentId);
        bool AddUserTopics(UserTopics userTopics);
        bool UpdateIsComplete(int studentId, int topicId, bool isComplete);
        bool Save();
    }
}
