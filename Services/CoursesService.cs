using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;

namespace backTOT.Services
{
    public class CoursesService : ICoursesService
    {
        private DataContext _context;
        public CoursesService(DataContext context)
        {
            _context = context;
        }
        public ICollection<Courses> GetCourses()
        {
            return _context.Courses.OrderBy(c => c.Id).ToList();
        }
    }
}
