using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IUsersLessonService
    {
        ICollection<UserLesson> GetUserLesson(Guid studentId);
        bool AddUserLesson(UserLesson userLesson);
        bool UpdateIsComplete(Guid studentId, Guid lessonId, bool isComplete);

        bool Save();
    }
}
