namespace backTOT.Entitys
{
    public class Sections
    {
        public int Id { get; set; }
        public string TitleVI { get; set; }
        public string TitleEN { get; set; }
        public string? DesVI { get; set; }
        public string? DesEN { get; set; }
        public int Courses_id { get; set; }
        public int Position { get; set; }

        // relation
        public Courses courses { get; set; }
        public ICollection<Lessons> Lessons { get; set; } = new List<Lessons>();
    }
}
