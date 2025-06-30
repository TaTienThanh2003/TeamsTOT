using System.ComponentModel.DataAnnotations.Schema;

namespace backTOT.Entitys
{
    public class UserTopics
    {
        public int Id { get; set; }

        public int UsersId { get; set; }
        public Users Users { get; set; }

        public int TopicsId { get; set; }

        public Topics Topics { get; set; }

        public bool IsComplete { get; set; }
    }

}
