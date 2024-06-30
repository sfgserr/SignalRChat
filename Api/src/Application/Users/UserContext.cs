using Application.Contracts;
using Domain.Users;

namespace Application.Users
{
    public class UserContext(IUserService userService) : IUserContext
    {
        private readonly IUserService _userService = userService;

        public UserId Id => new(_userService.GetUserId());
    }
}
