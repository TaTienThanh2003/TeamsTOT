using System.Collections;
using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IEnrollmentService 
    {
        bool AddEnrollment(Enrollments enrollment);
        ICollection<Enrollments> GetEnrollmentByUserId(int userId);
        bool Save();
    }
}
