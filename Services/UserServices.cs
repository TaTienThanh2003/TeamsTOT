using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using backTOT.Data;
using backTOT.Entities;
using backTOT.Entitys;
using backTOT.Interface;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;

namespace backTOT.Services
{
    public class UserServices : IUserServices
    {
        private DataContext _context;
        private readonly IConfiguration _config;
        public UserServices(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        

        public bool ischeckId(Guid userId)
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

        public Users GetUserId(Guid id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }


        public Users findUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(p => p.Email == email);
        }

        public bool deleteUser(Guid userId)
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


    }
}
