using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IUserServices
    {
        ICollection<Users> GetUsers();
        Users GetUsersId(int id);
        bool isCheckEmail(String email);
        bool isCheckPassword(String password);
        bool UsersLogin(String email,String password);
        bool UsersSignIn(Users users);
        bool Save();
    }
}
