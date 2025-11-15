using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ILesson_notes
    {
        bool addLessonNotes(Lesson_notes lessonNotes);
        ICollection<Lesson_notes> GetLesson_NotesByUser(Guid userId);
        ICollection<Lesson_notes> GetLesson_NotesByUserLesson(Guid userId, Guid lessonId);
        bool deleteLessonNotes(Guid lessonnoteId);
        bool Save();
    }
}
