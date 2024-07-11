using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<Group> Get(GroupId groupId);

        Task<List<TDto>> GetUserPermissions<TDto>(UserId userId);
    }
}
