using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;
using BCrypt.Net;

namespace backTOT.Services
{
    public class UserServices : IUserServices
    {
        private DataContext _context;
        public UserServices(DataContext context){
            _context = context;
        }
        public bool ischeckId(int userId)
        {
            _context.Users.FirstOrDefault(u => u.Id == userId);
            return Save();
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

        public Users GetUserId(int id)
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
            var user =  _context.Users.FirstOrDefault(p => p.Email == email );
            if (user == null) return false;
            // So sánh mật khẩu plaintext với password hash trong DB
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        public bool UsersSignIn(Users users)
        {
            users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);
            _context.Users.Add(users);
            return Save();
        }

        public ICollection<Users> GetTeacher()
        {
            return _context.Users.Where(t => t.Role == Role.TEACHER).ToList();
        }

        public Users findUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(p => p.Email == email);
        }

        public bool deleteUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            _context.Users.Remove(user);
            return Save();
        }

        public bool updateUser(Users user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser == null)
            {
                return false; // Không tìm thấy user
            }

            // Cập nhật các trường của existingUser với giá trị từ user
            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Phone = user.Phone;

            bool result = Save(); // Lưu thay đổi vào CSDL
            if (!result)
            {
                Console.WriteLine("Không thể lưu thay đổi vào CSDL");
            }

            return result; 
        }


        public bool UpdateUserRole(int userId, Role newRole)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return false;
            }

            user.Role = newRole;
            return Save();
        }


        public bool UpdatePassUser(int userId, string newPassword)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return false;
            // Mã hoá mật khẩu trước khi lưu
            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            return Save();
        }

    }
}
