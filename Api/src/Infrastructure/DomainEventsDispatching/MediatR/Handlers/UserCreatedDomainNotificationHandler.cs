using Application.Users.DomainEventHandlers;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class UserCreatedDomainNotificationHandler : IDomainNotificationHandler<UserCreatedDomainNotification>
    {
        private readonly UserCreatedDomainEventHandler _handler;

        internal UserCreatedDomainNotificationHandler(UserCreatedDomainEventHandler handler)
        {
            _handler = handler;
        }

        public async Task Handle(UserCreatedDomainNotification notification, CancellationToken cancellationToken)
        {
            await _handler.Handle(notification.DomainEvent);
        }
    }
}
