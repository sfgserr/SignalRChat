using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authorization
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string code) : base(policy: code)
        {
            Code = code;
        }

        public HasPermissionAttribute() : base(policy: "NoPermission")
        {
            Code = "NoPermission";
        }

        public string Code { get; }
    }
}
