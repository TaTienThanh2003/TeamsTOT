using Microsoft.AspNetCore.Authorization;

namespace backTOT.Middleware
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; }
        public PermissionRequirement(string permission) {
            Permission = permission;
        }
    }
}
