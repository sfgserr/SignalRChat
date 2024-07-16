using Application.Cqrs.Commands;
using Domain.Users;

namespace Application.Users.Commands.Register
{
    internal class RegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserCounter _userCounter;

        internal RegisterCommandHandler(IUserRepository userRepository, IUserCounter userCounter)
        {
            _userRepository = userRepository;
            _userCounter = userCounter;
        }

        public async Task Handle(RegisterCommand command)
        {
            string password = PasswordManager.HashPassword(command.Password);

            User user = User.Create(
                command.Login, 
                password, 
                command.IconUri, 
                _userCounter);

            await _userRepository.Add(user);
        }
    }
}
