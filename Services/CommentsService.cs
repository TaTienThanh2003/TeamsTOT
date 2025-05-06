using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;
using Microsoft.EntityFrameworkCore;

namespace backTOT.Services
{
    public class CommentsService :ICommentsService
    {
        private DataContext _context;
        public CommentsService(DataContext context)
        {
            _context = context;
        }

        public bool AddComments(Comments comments)
        {
            _context.Comments.Add(comments);
            return Save();
        }

        public ICollection<Comments> GetCommentsByLessonId(int lessonId)
        {
            return _context.Comments
                .Where(cm => cm.Lesson_id == lessonId)
                .Include(cm => cm.ParentComment)
                .Include(cm => cm.users)
                .OrderBy(cm => cm.Id)
                .ToList();
        }


        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
