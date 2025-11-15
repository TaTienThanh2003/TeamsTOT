using System.Collections;
using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IEnrollmentService 
    {
        bool AddEnrollment(Enrollments enrollment);
        ICollection<Enrollments> GetEnrollmentByUserId(Guid userId);
        bool CheckExistEnrollment(Guid userId, Guid courseId);
        bool Save();
    }
}
