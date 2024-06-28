using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Domain.Users
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppContext _appContext;

        internal UserRepository(AppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task Add(User entity)
        {
            await _appContext.Users.AddAsync(entity);
        }

        public async Task<User> Get(UserId userId)
        {
            return await _appContext.Users.FindAsync(userId);
        }

        public async Task<User> Get(string login)
        {
            return await _appContext.Users.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<List<User>> GetAll()
        {
            return await _appContext.Users.ToListAsync();
        }

        public void Update(User entity)
        {
            _appContext.Users.Update(entity);
        }
    }
}
