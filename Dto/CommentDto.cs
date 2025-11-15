namespace backTOT.Dto
{
    public class CommentDto
    {
        public Guid Lesson_id { get; set; }
        public Guid User_id { get; set; }
        public string Text { get; set; }
        public int? Parent_id { get; set; }
    }
}
