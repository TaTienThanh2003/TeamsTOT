using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ILessonsService
    {
        ICollection<Lessons> GetLessons();
        ICollection<Lessons> getLessonByCourses(int courseId);
    }
}
