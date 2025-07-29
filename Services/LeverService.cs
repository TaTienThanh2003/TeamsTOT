using backTOT.Data;
using Microsoft.EntityFrameworkCore;

namespace backTOT.Services
{
    public class LeverService
    {
        private DataContext _context;
        public LeverService(DataContext context)
        {
            _context = context;
        }
        public async Task<(int totalScore, string level)> CalculateUserLevelAsync(int userId)
        {
            // Đếm số bài học hoàn thành
            int completedLessons = await _context.UserLessons
                .CountAsync(ul => ul.Student_id == userId && ul.IsComplete == true);

            // Đếm số topic từ vựng hoàn thành
            int completedTopics = await _context.UserTopics
                .CountAsync(ut => ut.UsersId == userId && ut.IsComplete == true);

            // Tính tổng điểm
            int totalScore = completedLessons * 5 + completedTopics * 10;

            // Tính cấp độ: mỗi 20 điểm là 1 cấp, tối đa 10
            int baseLevel = totalScore / 20 + 1;
            string level = baseLevel > 10 ? "10++" : baseLevel.ToString();

            return (totalScore, level);
        }
    }
}
