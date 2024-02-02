using Grpc.Core;
using User.Grpc.Data.Repositories;
using User.Grpc.Models;
using User.Grpc.Protos;

namespace User.Grpc.Services
{
    public class UserService : UserProtoService.UserProtoServiceBase 
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async override Task<UserResponse> GetUsers(UserRequest userRequest, ServerCallContext context)
        {
            IList<ApplicationUser> users = await _repository.GetUsers();

            IList<UserModel> models = users.Select(u => new UserModel() { Name = u.UserName, Id = u.Id }).ToList();

            UserResponse response = new UserResponse();

            response.Users.AddRange(models);

            return response;
        }
    }
}
