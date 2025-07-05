using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IScheduleServices
    {
        ICollection<Schedules> GetSchedulesWithUser(int user_id);
        Schedules GetSchedulesByUserCourse(int user_id,int course_id);
        bool AddSchedules(Schedules schedules);
        bool isCheckScheduleExits(int user_id,int course_id);
        bool RemoveSchedules(int user_id,int course_id);
        bool Save();
    }
}
