using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authorization
{
    public class HasPermissionAttribute(string code) : AuthorizeAttribute
    {
        public string Code { get; } = code;
    }
}
