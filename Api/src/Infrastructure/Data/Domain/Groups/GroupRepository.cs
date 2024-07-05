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
            return await _applicationContext.Database
                .SqlQueryRaw<GroupUserPermission>("SELECT GroupUserPermissions FROM GroupUsers WHERE UserId = @p0", userId.Id)
                .ToListAsync();
        }

        public void Update(Group entity)
        {
            _applicationContext.Groups.Update(entity);
        }
    }
}
