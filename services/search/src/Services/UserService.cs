using IdentityServer.Grpc.Protos;

namespace Search.API.Services
{
    public class UserService
    {
        private readonly UserProtoService.UserProtoServiceClient _userService;

        public UserService(UserProtoService.UserProtoServiceClient userService)
        {
            _userService = userService;
        }

        public async Task<UserResponse> GetUsers()
        {
            return await _userService.GetUsersAsync(new UserRequest());
        }
    }
}
