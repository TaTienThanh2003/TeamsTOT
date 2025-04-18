using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;

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

        public ICollection<Enrollments> GetEnrollmentsByStudentId(int student_id)
        {
            return _context.Enrollments.OrderBy(c => c.Student_id == student_id).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
