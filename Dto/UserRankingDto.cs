namespace backTOT.Dto
{
    public class UserRankingDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public int Score { get; set; }
        public string Level { get; set; }
    }
}
