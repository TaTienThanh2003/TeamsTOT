using System.ComponentModel.DataAnnotations.Schema;

namespace backTOT.Entitys
{
    public class UserTopics
    {
        public Guid Id { get; set; }

        public Guid UsersId { get; set; }
        public Users Users { get; set; }

        public Guid TopicsId { get; set; }

        public Topics Topics { get; set; }

        public bool IsComplete { get; set; }
    }

}
