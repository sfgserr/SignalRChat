using Domain.Users;

namespace Application.Users.Commands.Register
{
    public sealed class RegisterCommandHandler(IUserRepository userRepository, IUserCounter userCounter) : 
        IRegisterCommandHandler
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserCounter _userCounter = userCounter;

        public async Task Handle(RegisterCommand command)
        {
            User user = User.Create(command.Login, command.Password, command.IconUri, _userCounter);

            await _userRepository.Add(user);
        }
    }
}
