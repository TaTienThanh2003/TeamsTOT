using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ILesson_notes
    {
        bool addLessonNotes(Lesson_notes lessonNotes);
        ICollection<Lesson_notes> GetLesson_NotesByUser(int userId);
        ICollection<Lesson_notes> GetLesson_NotesByUserLesson(int userId,int lessonId);
        bool Save();
    }
}
