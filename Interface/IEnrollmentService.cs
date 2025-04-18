using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IEnrollmentService 
    {
        bool AddEnrollment(Enrollments enrollment);
        ICollection<Enrollments> GetEnrollmentsByStudentId(int student_id);
        bool Save();
    }
}
