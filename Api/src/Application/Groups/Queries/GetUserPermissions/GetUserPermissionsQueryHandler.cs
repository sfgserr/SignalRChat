using Application.Cqrs.Queries;
using Domain.Groups;

namespace Application.Groups.Queries.GetUserPermissions
{
    public class GetUserPermissionsQueryHandler(IGroupRepository groupRepository) : 
        IQueryHandler<GetUserPermissionsQuery, List<GroupUserPermission>>
    {
        private readonly IGroupRepository _groupRepository = groupRepository;

        public async Task<List<GroupUserPermission>> Handle(GetUserPermissionsQuery query)
        {
            return await _groupRepository.GetUserPermissions(new(query.UserId));
        }
    }
}
