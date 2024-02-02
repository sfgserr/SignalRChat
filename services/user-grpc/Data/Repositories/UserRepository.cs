using User.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace User.Grpc.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ApplicationUser>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
