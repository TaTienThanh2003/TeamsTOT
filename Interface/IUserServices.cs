using backTOT.Entities;
using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IUserServices
    {
        ICollection<Users> GetUsers();
        Users GetUserId(Guid userId);
        Users findUserByEmail(String email);
        bool isCheckEmail(String email);
        bool ischeckId(Guid userId);
        bool deleteUser(Guid userId);
        bool updateUser(Users user);
        bool Save();
    }
}
