using backTOT.Entitys;
using Microsoft.AspNetCore.Authorization;

namespace backTOT.Middleware
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            // lấy ds permiss của user từ claims trong token
            var userPermisstion = context.User
                .FindAll("permission")
                .Select(c => c.Value);
            // nếu user có quyền khớp thì cho phép
            if (userPermisstion.Contains(requirement.Permission))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
