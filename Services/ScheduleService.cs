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

        public ICollection<Schedules> GetSchedulesWithUser(int user_id)
        {
            return _context.Schedules
                .Include(s => s.Courses)
                .Where(s => s.StudentId == user_id)
                .ToList();
        }

        public Schedules GetSchedulesByUserCourse(int user_id, int course_id)
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

        public bool isCheckScheduleExits(int user_id, int course_id)
        {
            return _context.Schedules
                .Any(s => s.StudentId == user_id && s.Courses_id == course_id);
        }

        public bool RemoveSchedules(int user_id, int course_id)
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
