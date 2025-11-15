using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IScheduleServices
    {
        ICollection<Schedules> GetSchedulesWithUser(Guid user_id);
        Schedules GetSchedulesByUserCourse(Guid user_id,Guid course_id);
        bool AddSchedules(Schedules schedules);
        bool isCheckScheduleExits(Guid user_id,Guid course_id);
        bool RemoveSchedules(Guid user_id, Guid course_id);
        bool Save();
    }
}
