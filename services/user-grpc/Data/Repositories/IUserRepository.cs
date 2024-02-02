using User.Grpc.Models;

namespace User.Grpc.Data.Repositories
{
    public interface IUserRepository
    {
        Task<IList<ApplicationUser>> GetUsers();
    }
}
