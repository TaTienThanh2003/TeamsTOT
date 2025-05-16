using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;
using Microsoft.EntityFrameworkCore;


namespace backTOT.Services
{
    public class LessonsService : ILessonsService
    {
        private DataContext _context;
        public LessonsService(DataContext context)
        {
            _context = context;
        }
        public Lessons GetLessonsById(int lessonId)
        {
            return _context.Lessons.FirstOrDefault(l => l.Id == lessonId);
        }
        public bool ischeckId(int lessonId)
        {
            _context.Lessons.FirstOrDefault(l => l.Id == lessonId);
            return Save();
        }

        public bool ischeckName(string name)
        {
            return _context.Lessons.Any(l => l.TitleVI == name);
        }
        public bool addLesson(Lessons lessons)
        {
            _context.Lessons.Add(lessons);
            return Save();
        }

        public bool deleteLesson(int lessonId)
        {
            var lesson = _context.Lessons.FirstOrDefault(l => l.Id == lessonId);
            _context.Lessons.Remove(lesson);
            return Save();
        }

        public ICollection<Sections> getLessonByCourses(int courseId)
        {
            return _context.Sections
                          .Where(s => s.Courses_id == courseId)
                          .Include(s => s.Lessons)
                          .ToList();
        }

        public ICollection<Lessons> GetLessons()
        {
            return _context.Lessons.OrderBy(l => l.Id).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool updateLesson(Lessons lessons)
        {
            var lesson = _context.Lessons.FirstOrDefault(l => l.Id == lessons.Id);
            if (lesson == null)
            {
                return false;
            }
            // Cập nhật
            lesson.TitleVI = lessons.TitleVI;
            lesson.TitleEN = lessons.TitleEN;
            lesson.DesVI = lessons.DesVI;
            lesson.DesEN = lessons.DesEN;
            lesson.Video_url = lessons.Video_url;
            lesson.Completed = lessons.Completed;
            lesson.Position = lessons.Position;
            return Save();
        }

    }
}
