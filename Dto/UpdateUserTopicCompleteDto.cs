namespace backTOT.Dto
{
    public class UpdateUserTopicCompleteDto
    {
        public Guid UserId { get; set; }
        public Guid TopicId { get; set; }
        public bool IsComplete { get; set; }
    }
}
