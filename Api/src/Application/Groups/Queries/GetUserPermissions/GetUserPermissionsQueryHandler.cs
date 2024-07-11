using Application.Cqrs.Queries;
using Domain.Groups;

namespace Application.Groups.Queries.GetUserPermissions
{
    public class GetUserPermissionsQueryHandler(IGroupRepository groupRepository) : 
        IQueryHandler<GetUserPermissionsQuery, List<PermissionDto>>
    {
        private readonly IGroupRepository _groupRepository = groupRepository;

        public async Task<List<PermissionDto>> Handle(GetUserPermissionsQuery query)
        {
            return await _groupRepository.GetUserPermissions<PermissionDto>(new(query.UserId));
        }
    }
}
