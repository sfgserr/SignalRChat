using Application.Contracts;
using Domain.Messages.Events;
using Domain.Users;

namespace Application.Messages.DomainEventHandlers
{
    public class MessageCreatedDomainEventHandler(IUserRepository userRepository, IEmailService emailService) : 
        IDomainEventHandler<MessageCreatedDomainEvent>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IEmailService _emailService = emailService;

        public async Task Handle(MessageCreatedDomainEvent domainEvent)
        {
            foreach(UserId id in domainEvent.Users)
            {
                User user = await _userRepository.Get(id);

                await _emailService.Send(user.Login, "New message at ");
            }
        }
    }
}
