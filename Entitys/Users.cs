using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backTOT.Entitys
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        USER,ADMIN, TEACHER
    }

    public class Users
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public String? FullName  { get; set; }
        [MaxLength(50)]
        public String Email { get; set; }
        public String Password { get; set; }
        [MaxLength(12)]
        public String? Phone { get; set; }
        public string? Image { get; set; } = "img/face.jpg";
        public String? Des { get; set; }
        
        public Role Role { get; set; } = Role.USER;
        
        public DateOnly created_ad { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        // relation
        public ICollection<Enrollments> Enrollments { get; set; } = new List<Enrollments>();
        [JsonIgnore]
        public ICollection<CourseTeachers> CourseTeachers { get; set; } = new List<CourseTeachers>();
        public ICollection<Scores> Scores { get; set; } = new List<Scores>();
        public ICollection<Carts> Carts { get; set; } = new List<Carts>();
        [JsonIgnore]
        public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
        public ICollection<User_plans> User_Plans { get; set; } = new List<User_plans>();
        public ICollection<Lesson_notes> Lesson_notes { get; set; } = new List<Lesson_notes>();
        public ICollection<Comments> Comments { get; set; } = new List<Comments>();
        public ICollection<Topics> Topics { get; set; } = new List<Topics>();
        public ICollection<Topics> TopicsCreated { get; set; }
        public ICollection<UserVocabularys> UserVocabularys { get; set; } = new List<UserVocabularys>();
        public ICollection<UserLesson> UserLessons { get; set; }
        public ICollection<Vocabularys> Vocabularys { get; set; }
        public ICollection<UserTopics> UserTopics { get; set; }
    }
}
