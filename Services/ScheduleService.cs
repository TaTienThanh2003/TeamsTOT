using backTOT.Data;
using backTOT.Entitys;
using System;
using backTOT.Interface;
using Microsoft.EntityFrameworkCore;

namespace backTOT.Services
{
    public class ScheduleService : IScheduleServices
    {
        private readonly DataContext _context;

        public ScheduleService(DataContext context)
        {
            _context = context;
        }

        public ICollection<Schedules> GetSchedulesWithUser(Guid user_id)
        {
            return _context.Schedules
                .Include(s => s.Courses)
                .Where(s => s.StudentId == user_id)
                .ToList();
        }

        public Schedules GetSchedulesByUserCourse(Guid user_id, Guid course_id)
        {
            return _context.Schedules
                .Include(s => s.Courses)
                .FirstOrDefault(s => s.StudentId == user_id && s.Courses_id == course_id);
        }

        public bool AddSchedules(Schedules schedules)
        {
            _context.Schedules.Add(schedules);
            return Save();
        }

        public bool isCheckScheduleExits(Guid user_id, Guid course_id)
        {
            return _context.Schedules
                .Any(s => s.StudentId == user_id && s.Courses_id == course_id);
        }

        public bool RemoveSchedules(Guid user_id, Guid course_id)
        {
            var schedule = _context.Schedules
                .FirstOrDefault(s => s.StudentId == user_id && s.Courses_id == course_id);

            if (schedule == null) return false;

            _context.Schedules.Remove(schedule);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
