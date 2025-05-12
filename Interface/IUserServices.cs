using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IUserServices
    {
        ICollection<Users> GetUsers();
        ICollection<Users> GetTeacher();
        Users GetUserId(int userId);
        Users findUserByEmail(String email);
        bool isCheckEmail(String email);
        bool isCheckPassword(String password);
        bool ischeckId(int userId);
        bool UsersLogin(String email,String password);
        bool UsersSignIn(Users users);
        bool deleteUser(int userId);
        bool updateUser(Users user);
        bool UpdateUserRole(int userId, Role newRole);
        bool UpdatePassUser(int userId, String pass);
        bool Save();
    }
}
