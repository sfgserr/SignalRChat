using Domain.Groups;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Domain.Groups
{
    internal class GroupRepository : IGroupRepository
    {
        private readonly ApplicationContext _applicationContext;

        internal GroupRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task Add(Group entity)
        {
            await _applicationContext.Groups.AddAsync(entity);
        }

        public async Task<Group> Get(GroupId groupId)
        {
            return await _applicationContext.Groups.FindAsync(groupId);
        }

        public async Task<List<Group>> GetAll()
        {
            return await _applicationContext.Groups.ToListAsync();
        }

        public async Task<List<GroupUserPermission>> GetUserPermissions(UserId userId)
        {
            Group? group = await _applicationContext.Set<Group>()
                .FirstOrDefaultAsync(u => u.Users.Any(u => u.UserId == userId));

            if (group is not null)
                return group.Users.Where(u => u.UserId == userId).First().Role.Permissions;

            return [];
        }

        public void Update(Group entity)
        {
            _applicationContext.Groups.Update(entity);
        }
    }
}
