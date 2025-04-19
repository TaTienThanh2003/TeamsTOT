using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IReviewsService
    {
        bool AddReview(Reviews review);
        bool HasUserEnrolledInCourse(int userId, int courseId);
        ICollection<Reviews> GetReviewsByCourse(int courseId);
        bool RemoveReview(int reviewId);
    }
}
