using Grpc.Core;
using IdentityServer.Data.Repositories;
using IdentityServer.Models;
using IdentityServer.Protos;

namespace IdentityServer.Services
{
    public class UserService : UserProtoService.UserProtoServiceBase 
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<UserModel>> GetUsers()
        {
            IList<ApplicationUser> users = await _repository.GetUsers();

            return users.Select(u => new UserModel() { Name = u.Name, Id = u.Id }).ToList();
        }
    }
}
