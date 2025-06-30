using backTOT.Entitys;
using Microsoft.EntityFrameworkCore;

namespace backTOT.Interface
{
    public interface ICartsService
    {
        ICollection<Courses> GetCartByUser(int userId);
        bool AddCourseOnCart(Carts cart);
        bool isCheckCoursesCart(int courseId);
        bool DeleteCourseOnCart(int courseId, int userID);
        public bool CheckExistCart(int userId, int courseId);
        bool Save();
    }
}
