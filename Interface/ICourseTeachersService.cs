using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ICourseTeachersService
    {
        ICollection<Users> GetTeacherByCourseId(Guid coureId);
    }
}
