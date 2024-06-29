using Application.Cqrs.Commands;
using Domain.Users;
using System.Security.Claims;

namespace Application.Users.Commands.Authenticate
{
    public sealed class AuthenticateCommandHandler(IUserRepository userRepository) : 
        ICommandHandlerWithResult<AuthenticateCommand, AuthenticationResult>
    {
        private readonly IUserRepository _userRepository = userRepository;

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
                new Claim("login", user.Login), 
                new Claim("password", user.Password)
            ]));
        }
    }
}
