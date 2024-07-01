using Application.Cqrs.Queries;
using Domain.Groups;

namespace Application.Groups.Queries.GetUserPermissions
{
    public class GetUserPermissionsQuery(Guid userId) : IQuery<List<GroupUserPermission>>
    {
        public Guid UserId { get; } = userId;
    }
}
