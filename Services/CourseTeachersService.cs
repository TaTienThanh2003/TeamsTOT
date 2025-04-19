using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;
using Microsoft.EntityFrameworkCore;

namespace backTOT.Services
{
    public class CourseTeachersService : ICourseTeachersService
    {
        private DataContext _context;
        public CourseTeachersService(DataContext context)
        {
            _context = context;
        }
        public ICollection<Users> GetTeacherByCourseId(int coureId)
        {
            return _context.CourseTeachers
                .AsNoTracking()
                .Include(ct => ct.Teacher)
                .Where(ct => ct.CourseId == coureId)
                .Select(ct => ct.Teacher)
                .ToList();
        }
    }
}
