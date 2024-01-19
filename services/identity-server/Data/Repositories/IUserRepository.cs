using IdentityServer.Models;

namespace IdentityServer.Data.Repositories
{
    public interface IUserRepository
    {
        Task<IList<ApplicationUser>> GetUsers();
    }
}
