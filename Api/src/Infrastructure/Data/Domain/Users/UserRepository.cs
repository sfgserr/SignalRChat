using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Domain.Users
{
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _applicationContext;

        internal UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task Add(User entity)
        {
            await _applicationContext.Users.AddAsync(entity);
        }

        public async Task<User> Get(UserId userId)
        {
            return await _applicationContext.Users.FindAsync(userId);
        }

        public async Task<User> Get(string login)
        {
            return await _applicationContext.Users.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<List<User>> GetAll()
        {
            return await _applicationContext.Users.ToListAsync();
        }

        public void Update(User entity)
        {
            _applicationContext.Users.Update(entity);
        }
    }
}
