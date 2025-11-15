using backTOT.Dto;
using backTOT.Entitys;
using Microsoft.EntityFrameworkCore;

namespace backTOT.Interface
{
    public interface ICartsService
    {
        ICollection<Courses> GetCartByUser(Guid userId);
        bool AddCourseOnCart(Carts cart);
        bool isCheckCoursesCart(Guid courseId);
        bool DeleteCourseOnCart(Guid courseId, Guid userID);
        bool CheckExistCart(Guid users_id, Guid course_id);
        bool Save();
    }
}
