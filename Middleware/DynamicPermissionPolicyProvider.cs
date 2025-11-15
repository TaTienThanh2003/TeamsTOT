using backTOT.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace backTOT.Middleware
{
    // 1. Policy Provider
    public class DynamicPermissionPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        public DynamicPermissionPolicyProvider(IOptions<AuthorizationOptions> options)
            : base(options)
        {
        }

        public override Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith("Permission:", StringComparison.OrdinalIgnoreCase))
            {
                var perm = policyName.Split(':')[1];

                // Chỉ build policy với requirement, không lấy cache
                var policy = new AuthorizationPolicyBuilder()
                    .AddRequirements(new PermissionRequirement(perm))
                    .Build();

                return Task.FromResult<AuthorizationPolicy?>(policy);
            }

            return base.GetPolicyAsync(policyName);
        }
    }

}
