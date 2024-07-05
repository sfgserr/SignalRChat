using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authorization
{
    public class HasPermissionAttribute(string code) : AuthorizeAttribute(policy: code)
    {
        public string Code { get; } = code;
    }
}
