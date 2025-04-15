using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;

namespace backTOT.Services
{
    public class CartsService : ICartsService
    {
        private DataContext _context;
        public CartsService(DataContext context)
        {
            _context = context;
        }
        public bool AddCourseOnCart(Carts cart)
        {
            _context.Carts.Add(cart);
            return Save();
        }
        public bool isCheckCoursesCart(int courseId)
        {
            var isbool = _context.Carts.FirstOrDefault(c => c.Course_id == courseId);
            return isbool != null;
        }
        public bool DeleteCourseOnCart(int courseId, int userID)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Course_id == courseId && c.Users_id == userID);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
            }
            return Save();
        }

        public ICollection<Carts> GetCartByUser(int userId)
        {
            return _context.Carts.OrderBy(c => c.Users_id == userId).ToList();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public decimal TinhTongTienCart(int cartId)
        {
            throw new NotImplementedException();
        }
    }
}
