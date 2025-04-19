using System.Collections;
using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IEnrollmentService 
    {
        bool AddEnrollment(Enrollments enrollment);
        ICollection<Courses> GetCoursesByUserId(int userId);
        bool Save();
    }
}
