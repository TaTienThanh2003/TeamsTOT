using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IUserServices
    {
        ICollection<Users> GetUsers();
    }
}
