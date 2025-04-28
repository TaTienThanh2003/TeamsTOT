using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;
using Microsoft.EntityFrameworkCore;

namespace backTOT.Services
{
    public class EnrollmentsService : IEnrollmentService
    {
        private DataContext _context;
        public EnrollmentsService(DataContext context)
        {
            _context = context;
        }
        public bool AddEnrollment(Enrollments enrollment)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == enrollment.Courses_id);
            if (course == null) return false ;
            // gán dữ liệu course
            enrollment.courses = course;
            enrollment.CalculateEndDate();
            _context.Enrollments.Add(enrollment);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public ICollection<Enrollments> GetEnrollmentByUserId(int userId)
        {
           return  _context.Enrollments
                .Include(e => e.courses)
                .Where(e => e.Student_id == userId)
                .ToList();
        }
    }
}
