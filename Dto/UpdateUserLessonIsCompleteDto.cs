namespace backTOT.Dto
{
    public class UpdateUserLessonIsCompleteDto
    {
        public Guid Student_id { get; set; }
        public Guid LessonsId { get; set; }
        public bool IsComplete { get; set; }
    }
}
