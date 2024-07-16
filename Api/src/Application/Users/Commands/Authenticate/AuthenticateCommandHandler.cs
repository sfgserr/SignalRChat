using Application.Cqrs.Commands;
using Domain.Users;
using System.Security.Claims;

namespace Application.Users.Commands.Authenticate
{
    internal class AuthenticateCommandHandler : ICommandHandlerWithResult<AuthenticateCommand, AuthenticationResult>
    {
        private readonly IUserRepository _userRepository;

        internal AuthenticateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(AuthenticateCommand command)
        {
            User user = await _userRepository.Get(command.Login);

            if (user == null)
            {
                return new AuthenticationResult("Login or password incorrect");
            }

            if (!PasswordManager.VerifyHashedPassword(user.Password, command.Password))
            {
                return new AuthenticationResult("Login or password incorrect");
            }

            return new AuthenticationResult(new UserDto(
            [
                new Claim("id", user.Id.Value.ToString()),
                new Claim("login", user.Login), 
                new Claim("password", user.Password)
            ]));
        }
    }
}
