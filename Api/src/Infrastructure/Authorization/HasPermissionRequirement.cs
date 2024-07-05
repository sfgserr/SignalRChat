using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authorization
{
    public class HasPermissionRequirement : IAuthorizationRequirement
    {
        public HasPermissionRequirement(string permission)
        {
            PermissionCode = permission;
        }

        public string PermissionCode { get; }
    }
}
