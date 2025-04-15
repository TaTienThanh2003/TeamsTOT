using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ICoursesService
    {
        ICollection<Courses> GetCourses();
        ICollection<Courses> GetCoursesByName(String name);
    }
}
