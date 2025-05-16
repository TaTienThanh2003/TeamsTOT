using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;
using Microsoft.EntityFrameworkCore;

namespace backTOT.Services
{
    public class CoursesService : ICoursesService
    {
        private DataContext _context;
        public CoursesService(DataContext context)
        {
            _context = context;
        }

        public bool addCourse(Courses courses)
        {
            _context.Courses.Add(courses);
            return Save();
        }

        public bool deleteCourse(int courseId)
        {
           var course =  _context.Courses.FirstOrDefault(c => c.Id == courseId);
            _context.Courses.Remove(course);
            return Save();
        }

        public ICollection<Courses> GetCourses()
        {
            return _context.Courses.OrderBy(c => c.Id).ToList();
        }

        public Courses GetCoursesById(int courseId)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == courseId);
        }


        public ICollection<Courses> GetCoursesByName(string name)
        {
            string keyword = TextUtils.RemoveDiacritics(name).ToLower();

            return _context.Courses
                .AsEnumerable()
                .Where(c => TextUtils.RemoveDiacritics(c.TitleVI).ToLower().Contains(keyword))
                .ToList();
        }
        public ICollection<Courses> GetCoursesByOffline()
        {
            return _context.Courses.Where(c => c.Mode == Mode.OFFLINE)
                .Include(c => c.courseOff)
                .ToList();
        }

        public ICollection<Courses> GetCoursesByOnline()
        {
            return _context.Courses.Where(c => c.Mode == Mode.ONLINE).ToList();
        }

        public bool ischeckId(int courseId)
        {
            _context.Courses.FirstOrDefault(c => c.Id == courseId);
            return Save();
        }

        public bool ischeckName(string name)
        {
            return _context.Courses.Any(c => c.TitleVI == name);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool updateCourse(Courses courses)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == courses.Id);
            if (course == null)
            {
                return false; 
            }
            // Cập nhật
            course.TitleVI = courses.TitleVI;
            course.TitleEN = courses.TitleEN;
            course.DesVI = courses.DesVI;
            course.DesEN = courses.DesEN;
            course.price = courses.price;
            course.Img = courses.Img;
            course.Mode = courses.Mode;
            course.CountDay = courses.CountDay;
            return Save(); 
        }
    }
}
