namespace backTOT.Dto
{
    public class EnrollmentDtoResponse
    {
        public DateOnly Start_date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly? End_date { get; set; }
        public CoursesDto courses { get; set; }
    }
}
