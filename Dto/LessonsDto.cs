namespace backTOT.Dto
{
    public class LessonsDto
    {
        public int Section_id { get; set; }
        public string TitleVI { get; set; }
        public string TitleEN { get; set; }
        public string DesVI { get; set; }
        public string DesEN { get; set; }
        public string Video_url { get; set; }
        public Boolean Completed { get; set; }
        public int Position { get; set; }
    }
}
