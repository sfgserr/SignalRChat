using Application.Contracts;
using Application.Cqrs.Commands;
using Domain.Users;

namespace Application.Groups.Commands.SendEmailToAddedUser
{
    internal class SendEmailToAddedUserCommandHandler : ICommandHandler<SendEmailToAddedUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        internal SendEmailToAddedUserCommandHandler(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task Handle(SendEmailToAddedUserCommand command)
        {
            User user = await _userRepository.Get(command.AddedUserId);

            await _emailService.Send(user.Login, $"You was added to group:{command.GroupId}");
        }
    }
}
