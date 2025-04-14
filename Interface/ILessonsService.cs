using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ILessonsService
    {
        ICollection<Lessons> GetLessons();
        Lessons getLessonByCourses(int courseId);
    }
}
