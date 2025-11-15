using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ILessonsService
    {
        ICollection<Lessons> GetLessons();
        ICollection<Sections> getLessonByCourses(Guid lessonId);
        Lessons GetLessonsById(Guid lessonId);
        bool ischeckId(Guid lessonId);
        bool ischeckName(String name);
        bool addLesson(Lessons lessons);
        bool deleteLesson(Guid lessonId);
        bool updateLesson(Lessons lessons);
        bool Save();
    }
}
