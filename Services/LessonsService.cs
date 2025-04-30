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

    }
}
