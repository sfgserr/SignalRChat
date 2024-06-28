using Domain.Groups;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Domain.Groups
{
    internal class GroupRepository : IGroupRepository
    {
        private readonly AppContext _appContext;

        internal GroupRepository(AppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task Add(Group entity)
        {
            await _appContext.Groups.AddAsync(entity);
        }

        public async Task<Group> Get(GroupId groupId)
        {
            return await _appContext.Groups.FindAsync(groupId);
        }

        public async Task<List<Group>> GetAll()
        {
            return await _appContext.Groups.ToListAsync();
        }

        public void Update(Group entity)
        {
            _appContext.Groups.Update(entity);
        }
    }
}
