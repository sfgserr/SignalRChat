using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<Group> Get(GroupId groupId);

        List<TDto> GetUserPermissions<TDto>(UserId userId);
    }
}
