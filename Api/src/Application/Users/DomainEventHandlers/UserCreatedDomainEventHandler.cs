using Application.Contracts;
using Domain.Users.Events;

namespace Application.Users.DomainEventHandlers
{
    public class UserCreatedDomainEventHandler(IEmailService emailService) : 
        IDomainEventHandler<UserCreatedDomainEvent>
    {
        private readonly IEmailService _emailService = emailService;

        public async Task Handle(UserCreatedDomainEvent domainEvent)
        {
            await _emailService.Send(domainEvent.Login, "Account created successfully");
        }
    }
}
