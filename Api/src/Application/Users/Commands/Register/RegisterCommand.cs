using Application.Cqrs.Commands;

namespace Application.Users.Commands.Register
{
    public class RegisterCommand(string login, string password, string iconUri) : ICommand
    {
        public string Login { get; } = login;

        public string Password { get; } = password;

        public string IconUri { get; } = iconUri;
    }
}
