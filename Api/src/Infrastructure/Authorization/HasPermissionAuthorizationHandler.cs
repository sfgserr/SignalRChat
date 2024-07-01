using Application.Contracts;
using Application.Cqrs.Queries;
using Application.Groups.Queries.GetUserPermissions;
using Domain.Groups;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authorization
{
    public class HasPermissionAuthorizationHandler(
        IUserService userService,
        IQueryHandler<GetUserPermissionsQuery,List<GroupUserPermission>> handler) : 
        AttributeAuthorizationHandler<HasPermissionRequirement, HasPermissionAttribute>
    {
        private readonly IUserService _userService = userService;
        private readonly IQueryHandler<GetUserPermissionsQuery, List<GroupUserPermission>> _handler = handler;

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            HasPermissionAttribute attribute, 
            HasPermissionRequirement requirement)
        {
            Guid id = _userService.GetUserId();

            var permissions = await _handler.Handle(new(id));

            if (Authorize(permissions, attribute.Code))
            {
                context.Succeed(requirement);
                return;
            }

            context.Fail();
        }

        private bool Authorize(List<GroupUserPermission> permissions, string code)
        {
            return permissions.Any(p => p.Code == code);
        }
    }
}
