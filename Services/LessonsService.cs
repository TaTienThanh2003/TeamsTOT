using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;


namespace backTOT.Services
{
    public class LessonsService : ILessonsService
    {
        private DataContext _context;
        public LessonsService(DataContext context)
        {
            _context = context;
        }

        public Lessons getLessonByCourses(int courseId)
        {
            return _context.Lessons.FirstOrDefault(l => l.Courses_id == courseId);
        }

        public ICollection<Lessons> GetLessons()
        {
            return _context.Lessons.OrderBy(l => l.Id).ToList();
        }

    }
}
