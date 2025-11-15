using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ICoursesService
    {
        ICollection<Courses> GetCourses();
        ICollection<Courses> GetCoursesByOnline();
        ICollection<Courses> GetCoursesByOffline();
        ICollection<Courses> GetCoursesByCatalogId(Guid catalogId, int num);
        ICollection<Courses> GetCoursesOfflineByCatalogId(Guid catalogId);
        Courses GetCoursesById(Guid courseId);
        ICollection<Courses> GetCoursesByName(String name);
        bool addCourse(Courses courses);
        bool deleteCourse(Guid courseId);
        bool updateCourse(Courses courses);
        bool ischeckId(Guid courseId);
        bool ischeckName(String name);
        bool Save();

    }
}
