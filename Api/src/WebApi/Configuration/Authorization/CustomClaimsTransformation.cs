using Application.Contracts;
using Application.Groups.Queries.GetUserPermissions;
using Domain.Groups;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace WebApi.Configuration.Authorization
{
    public sealed class CustomClaimsTransformation(IAppModule appModule) : IClaimsTransformation
    {
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            string? id = principal.FindFirst("id")?.Value;

            if (id is not null)
            {
                var permissions = await appModule.Query<GetUserPermissionsQuery, List<PermissionDto>>(
                    new GetUserPermissionsQuery(Guid.Parse(id)));

                var claimsIdentity = new ClaimsIdentity();

                foreach (var permission in permissions)
                    claimsIdentity.AddClaim(new("Permission", permission.Code));

                principal.AddIdentity(claimsIdentity);

                return principal;
            }

            throw new ApplicationException("User don't have id");
        }
    }
}
