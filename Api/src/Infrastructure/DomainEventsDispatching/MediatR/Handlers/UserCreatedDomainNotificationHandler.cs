using Application.Contracts;
using Domain.Users.Events;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class UserCreatedDomainNotificationHandler : IDomainNotificationHandler<UserCreatedDomainNotification>
    {
        private readonly IEmailService _emailService;

        internal UserCreatedDomainNotificationHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(UserCreatedDomainNotification notification, CancellationToken cancellationToken)
        {
            UserCreatedDomainEvent @event = notification.DomainEvent;

            await _emailService.Send(@event.Login, "You have created account");
        }
    }
}
