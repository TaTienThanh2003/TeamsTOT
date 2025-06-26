namespace backTOT.Dto
{
    public class UpdateUserTopicCompleteDto
    {
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public bool IsComplete { get; set; }
    }
}
