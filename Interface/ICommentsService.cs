using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ICommentsService
    {
        ICollection<Comments> GetCommentsByLessonId(int lessonId);
        bool AddComments(Comments comments);
        bool Save();
    }
}
