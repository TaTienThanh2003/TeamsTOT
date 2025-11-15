using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;
using Microsoft.EntityFrameworkCore;

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
        public bool isCheckCoursesCart(Guid courseId)
        {
            var isbool = _context.Carts.FirstOrDefault(c => c.Course_id == courseId);
            return isbool != null;
        }
        public bool DeleteCourseOnCart(Guid courseId, Guid userID)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Course_id == courseId && c.Users_id == userID);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
            }
            return Save();
        }
        public ICollection<Courses> GetCartByUser(Guid userId)
        {
            var result = (from cart in _context.Carts
                          join course in _context.Courses
                              on cart.Course_id equals course.Id
                          where cart.Users_id == userId
                          select course).ToList();

            return result;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool CheckExistCart(Guid userId, Guid courseId)
        {
            return _context.Carts.Any(c => c.Users_id == userId && c.Course_id == courseId);
        }

    }
}
