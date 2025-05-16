using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ILessonsService
    {
        ICollection<Lessons> GetLessons();
        ICollection<Sections> getLessonByCourses(int lessonId);
        Lessons GetLessonsById(int lessonId);
        bool ischeckId(int lessonId);
        bool ischeckName(String name);
        bool addLesson(Lessons lessons);
        bool deleteLesson(int lessonId);
        bool updateLesson(Lessons lessons);
        bool Save();
    }
}
