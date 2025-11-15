namespace backTOT.Entities
{
    public class AuditLog
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string HttpMethod { get; set; } = "";
        public string Endpoint { get; set; } = "";
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string? Details { get; set; }
    }
}
