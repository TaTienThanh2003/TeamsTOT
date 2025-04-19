using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;
using Microsoft.EntityFrameworkCore;

namespace backTOT.Services
{
    public class ReviewsService : IReviewsService
    {
        private DataContext _context;
        public ReviewsService(DataContext context)
        {
            _context = context;
        }
        public bool AddReview(Reviews review)
        {
            _context.Reviews.Add(review);
            return Save();
        }
        public ICollection<Reviews> GetReviewsByCourse(int courseId)
        {
            return _context.Reviews
                .AsNoTracking()
                .Where(r => r.CourseId == courseId)
                .Include(r => r.users)
                .ToList();
        }

        public bool HasUserEnrolledInCourse(int userId, int courseId)
        {
            return _context.Enrollments.Any(e => e.Student_id == userId && e.Courses_id == courseId);
        }

        public bool RemoveReview(int reviewId)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.Id == reviewId);
            if (review != null)
            {
                _context.Reviews.Remove(review);
            }
            return Save();
        }
        private bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
