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
    }
}
