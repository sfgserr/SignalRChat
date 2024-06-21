using Application.Cqrs.Queries;

namespace Application.Groups.Queries.GetUserGroups
{
    public sealed class GetUserGroupsQuery : IQuery<IList<GroupDto>>
    {
        public Guid UserId { get; }
    }
}
