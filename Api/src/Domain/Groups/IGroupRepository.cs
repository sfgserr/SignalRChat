using Domain.SeedWork;

namespace Domain.Groups
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<Group> Get(GroupId groupId);
    }
}
