using backTOT.Entitys;

namespace backTOT.Entities
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public Users? User { get; set; } = null!;

        public Guid RoleId { get; set; }
        public Role? Role { get; set; } = null!;
    }
}
