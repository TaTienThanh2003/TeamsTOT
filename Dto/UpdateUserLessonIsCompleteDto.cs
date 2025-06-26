namespace backTOT.Dto
{
    public class UpdateUserLessonIsCompleteDto
    {
        public int Student_id { get; set; }
        public int LessonsId { get; set; }
        public bool IsComplete { get; set; }
    }
}
