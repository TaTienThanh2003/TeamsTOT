using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IUsersLessonService
    {
        ICollection<UserLesson> GetUserLesson(int studentId);
        bool AddUserLesson(UserLesson userLesson);
        bool UpdateIsComplete(int studentId, int lessonId, bool isComplete);

        bool Save();
    }
}
