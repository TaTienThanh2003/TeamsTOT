using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;

namespace backTOT.Services
{
    public class Lesson_NotesService : ILesson_notes
    {
        private DataContext _context;
        public Lesson_NotesService(DataContext context)
        {
            _context = context;
        }
        public bool addLessonNotes(Lesson_notes lessonNotes)
        {
             _context.Lesson_notes.Add(lessonNotes);
            return Save();
        }

        public ICollection<Lesson_notes> GetLesson_NotesByUser()
        {
            return _context.Lesson_notes.OrderBy(gn => gn.Id).ToList();
        }

        public ICollection<Lesson_notes> GetLesson_NotesByUser(int userId)
        {
            return _context.Lesson_notes
                .Where(gn => gn.User_id == userId)
                .ToList();
        }

        public ICollection<Lesson_notes> GetLesson_NotesByUserLesson(int userId, int lessonId)
        {
            return _context.Lesson_notes
                .Where(gn => gn.User_id == userId && gn.Lesson_id == lessonId)
                .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
