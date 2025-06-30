using backTOT.Entitys;
using System.ComponentModel.DataAnnotations;

namespace backTOT.Dto
{
    public class TopicUserDtoLean
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WordCount { get; set; }
        public string ImageUrl { get; set; }
        public string? Des { get; set; }
        public int? UsersCreated_id { get; set; }
        // relation
        public Users UserCreated { get; set; }
        public ICollection<UserTopicDto> Users { get; set; } = new List<UserTopicDto>();
        public ICollection<Vocabularys> Vocabulary { get; set; } = new List<Vocabularys>();
    }
}
