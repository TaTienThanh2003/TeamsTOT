using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IUserServices
    {
        ICollection<Users> GetUsers();
        ICollection<Users> GetTeacher();
        Users GetUsersId(int id);
        Users findUserByEmail(String email);
        bool isCheckEmail(String email);
        bool isCheckPassword(String password);
        bool UsersLogin(String email,String password);
        bool UsersSignIn(Users users);
        bool Save();
    }
}
