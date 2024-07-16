using Application.Cqrs.Queries;

namespace Application.Groups.Queries.GetUserGroups
{
    public class GetUserGroupsQuery : IQuery<IList<GroupDto>>
    {
        public Guid UserId { get; }
    }
}
