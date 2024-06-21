using Application.Cqrs.Queries;

namespace Application.Groups.Queries.GetUserGroups
{
    public interface IGetUserGroupsQueryHandler : IQueryHandler<GetUserGroupsQuery, IList<GroupDto>>
    {
    }
}
