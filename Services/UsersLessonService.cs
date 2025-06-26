
using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;

namespace backTOT.Services
{
    public class UsersLessonService : IUsersLessonService
    {
        private DataContext _context;
        public UsersLessonService(DataContext context)
        {
            _context = context;
        }
        public bool AddUserLesson(UserLesson userLesson)
        {
            _context.UserLessons.Add(userLesson);
            return Save();
        }
        public ICollection<UserLesson> GetUserLesson(int studentId)
        {
           return  _context.UserLessons.Where(ul => ul.Student_id == studentId).ToList();
        }
        public bool UpdateIsComplete(int studentId, int lessonId, bool isComplete)
        {
            var userLesson = _context.UserLessons
                .FirstOrDefault(ul => ul.Student_id == studentId && ul.LessonsId == lessonId);

            if (userLesson == null)
                return false;

            userLesson.IsComplete = isComplete;
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
