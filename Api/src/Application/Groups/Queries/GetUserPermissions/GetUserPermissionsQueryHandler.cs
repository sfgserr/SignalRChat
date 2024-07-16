using Application.Cqrs.Queries;
using Domain.Groups;

namespace Application.Groups.Queries.GetUserPermissions
{
    internal class GetUserPermissionsQueryHandler : IQueryHandler<GetUserPermissionsQuery, List<PermissionDto>>
    {
        private readonly IGroupRepository _groupRepository;

        internal GetUserPermissionsQueryHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public Task<List<PermissionDto>> Handle(GetUserPermissionsQuery query)
        {
            return Task.FromResult(_groupRepository.GetUserPermissions<PermissionDto>(new(query.UserId)));
        }
    }
}
