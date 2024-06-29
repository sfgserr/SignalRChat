using Application.Cqrs.Queries;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Queries.GetUserGroups
{
    public sealed class GetUserGroupsQueryHandler(IGroupRepository groupRepository) : 
        IQueryHandler<GetUserGroupsQuery, IList<GroupDto>>
    {
        private readonly IGroupRepository _groupRepository = groupRepository;

        public async Task<IList<GroupDto>> Handle(GetUserGroupsQuery query)
        {
            IList<Group> groups = await _groupRepository.GetAll();

            IList<GroupDto> userGroups = groups.Where(g => g.Users.Any(u => u.UserId == new UserId(query.UserId)))
                .Select(g => new GroupDto(g)).ToList();

            return userGroups;
        }
    }
}
