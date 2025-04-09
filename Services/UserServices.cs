using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;

namespace backTOT.Services
{
    public class UserServices : IUserServices
    {
        private DataContext _context;
        public UserServices(DataContext context){
            _context = context;
        }
        public ICollection<Users> GetUsers()
        {
            return _context.Users.OrderBy(p => p.Id).ToList();
        }

        public bool isCheckEmail(string email)
        {
            var isbool = _context.Users.FirstOrDefault(p => p.Email == email);
            return isbool != null;
        }
        public bool isCheckPassword(string password)
        {
            var isbool = _context.Users.FirstOrDefault(p => p.Password == password);
            return isbool != null;
        }

        public Users GetUsersId(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UsersLogin(string email, string password)
        {
             _context.Users.FirstOrDefault(p => p.Email == email && p.Password == password);
            return Save();
        }

        public bool UsersSignIn(Users users)
        {
             _context.Users.Add(users);
            return Save();
        }
    }
}
