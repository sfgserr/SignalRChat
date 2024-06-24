using Application.Cqrs.Commands;

namespace Application.Users.Commands.Authenticate
{
    public sealed class AuthenticateCommand(string login, string password) : ICommandWithResult<AuthenticationResult>
    {
        public string Login { get; } = login;

        public string Password { get; } = password;
    }
}
