using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;
using Microsoft.EntityFrameworkCore;

namespace backTOT.Services
{
    public class UserVocabularysService : IUserVocabularysService
    {
        private DataContext _context;
        public UserVocabularysService(DataContext context)
        {
            _context = context;
        }

        public bool AddUserVocabularys(UserVocabularys userVocabularys)
        {
            _context.UserVocabularys.Add(userVocabularys);
            return Save();
        }

        public ICollection<UserVocabularys> GetUserVocabularys(int studentId, int topicId)
        {
            return _context.UserVocabularys
                .Where(x => x.Student_id == studentId && x.TopicId == topicId && x.IsActive)
                .Include(x => x.Vocabularys) 
                .ToList();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
