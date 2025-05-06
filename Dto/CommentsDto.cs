namespace backTOT.Dto
{

        public class CommentsDto
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public int Likes { get; set; }
            public int DisLikes { get; set; }
            public int? Parent_id { get; set; }

            public UsersCommentsDto User { get; set; }

            public List<CommentsDto> Replies { get; set; } = new List<CommentsDto>();
        }
}
