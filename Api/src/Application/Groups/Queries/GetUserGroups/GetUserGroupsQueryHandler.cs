using Application.Cqrs.Queries;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Queries.GetUserGroups
{
    internal class GetUserGroupsQueryHandler : IQueryHandler<GetUserGroupsQuery, IList<GroupDto>>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserContext _userContext;

        internal GetUserGroupsQueryHandler(IGroupRepository groupRepository, IUserContext userContext)
        {
            _groupRepository = groupRepository;
            _userContext = userContext;
        }

        public async Task<IList<GroupDto>> Handle(GetUserGroupsQuery query)
        {
            IList<Group> groups = await _groupRepository.GetAll();

            IList<GroupDto> userGroups = groups.Where(g => g.Users.Any(u => u.UserId.Equals(_userContext.Id)))
                .Select(g => new GroupDto(g)).ToList();

            return userGroups;
        }
    }
}
