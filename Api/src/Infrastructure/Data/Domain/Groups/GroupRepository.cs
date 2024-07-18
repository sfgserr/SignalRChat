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
            return await _applicationContext.Groups
                .Include(g => g.Users)
                .FirstOrDefaultAsync(g => g.Id == groupId);
        }

        public async Task<List<Group>> GetAll()
        {
            return await _applicationContext.Groups.Include(u => u.Users).ToListAsync();
        }

        public List<TDto> GetUserPermissions<TDto>(UserId userId)
        {
            const string sql = $"""
                                SELECT gurp.Code
                                FROM GroupUsers gu
                                JOIN GroupUserRoles gur ON gu.RoleValue = gur.Value
                                JOIN GroupUserRolePermissions gurp ON gur.Id = gurp.GroupUserRoleId
                                WHERE gu.UserId = @p0
                                """;

            var permissions = _applicationContext.Database.SqlQueryRaw<TDto>(sql, userId.Value);

            return permissions.Any() ? [..permissions] : [];
        }
    }
}
