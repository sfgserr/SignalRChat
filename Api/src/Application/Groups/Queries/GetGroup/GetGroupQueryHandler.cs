using Application.Cqrs.Queries;
using Domain.Groups;

namespace Application.Groups.Queries.GetGroup
{
    internal class GetGroupQueryHandler : IQueryHandler<GetGroupQuery, GroupDto>
    {
        private readonly IGroupRepository _groupRepository;

        internal GetGroupQueryHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<GroupDto> Handle(GetGroupQuery query)
        {
            Group group = await _groupRepository.Get(new GroupId(query.GroupId));

            return new GroupDto(group);
        }
    }
}
