namespace backTOT.Entitys
{
    public class Comments
    {
        public int Id { get; set; }
        public int Lesson_id { get; set; }
        public int User_id { get; set; }
        public string Text  { get; set;}
        public int Likes { get; set; } = 0;
        public int DisLikes { get; set; } = 0;
        public int? Parent_id { get; set; }
        public Comments ParentComment { get; set; }
        public ICollection<Comments> Replies { get; set; }
        // ralation
        public Lessons lessons { get; set; }
        public Users users { get; set; }
    }
}
