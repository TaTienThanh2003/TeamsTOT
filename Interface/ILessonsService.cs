using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ILessonsService
    {
        ICollection<Lessons> GetLessons();
        ICollection<Sections> getLessonByCourses(int courseId);
    }
}
