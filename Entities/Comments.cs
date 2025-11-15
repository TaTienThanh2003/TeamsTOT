namespace backTOT.Entitys
{
    public class Comments
    {
        public Guid Id { get; set; }
        public Guid Lesson_id { get; set; }
        public Guid User_id { get; set; }
        public string Text  { get; set;}
        public int Likes { get; set; } = 0;
        public int DisLikes { get; set; } = 0;
        public Guid? Parent_id { get; set; }
        public Comments ParentComment { get; set; }
        public ICollection<Comments> Replies { get; set; }
        // ralation
        public Lessons lessons { get; set; }
        public Users users { get; set; }
    }
}
