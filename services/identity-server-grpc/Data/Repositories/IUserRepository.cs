using IdentityServer.Grpc.Models;

namespace IdentityServer.Grpc.Data.Repositories
{
    public interface IUserRepository
    {
        Task<IList<ApplicationUser>> GetUsers();
    }
}
