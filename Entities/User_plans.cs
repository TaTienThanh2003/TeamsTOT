using System.Text.Json.Serialization;

namespace backTOT.Entitys
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        ACTIVE, EXPIRED, CANCELED
    }
    public class User_plans
    {
        public Guid Id { get; set; }
        public Guid User_id { get; set; }
        public Guid Plan_id { get; set; }
        public DateOnly Start_date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly? End_date { get; set; }
        public DateOnly created_ad { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public Status Status { get; set; } = Status.ACTIVE;

        // relation
        public Users users { get; set; }
        public Plans plans { get; set; }
    }
}
