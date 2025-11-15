using backTOT.Entitys;

namespace backTOT.Entities
{
    public class UserPermission
    {
        public Guid UserId { get; set; }
        public Users User { get; set; } = null!;

        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; } = null!;

        public bool IsGranted { get; set; }
    }
}
