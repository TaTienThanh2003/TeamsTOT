using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ICoursesService
    {
        ICollection<Courses> GetCourses();
        Courses GetCoursesById(int courseId);
        ICollection<Courses> GetCoursesByName(String name);
        bool addCourse(Courses courses);
        bool deleteCourse(int courseId);
        bool updateCourse(Courses courses);
        bool ischeckId(int courseId);
        bool ischeckName(String name);
        bool Save();

    }
}
