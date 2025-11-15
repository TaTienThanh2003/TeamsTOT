using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IReviewsService
    {
        bool AddReview(Reviews review);
        bool HasUserEnrolledInCourse(Guid userId, Guid courseId);
        ICollection<Reviews> GetReviewsByCourse(Guid courseId);
        bool RemoveReview(Guid reviewId);
    }
}
