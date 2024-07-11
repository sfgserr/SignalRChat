using Application.Cqrs.Queries;

namespace Application.Groups.Queries.GetUserPermissions
{
    public class GetUserPermissionsQuery(Guid userId) : IQuery<List<PermissionDto>>
    {
        public Guid UserId { get; } = userId;
    }
}
