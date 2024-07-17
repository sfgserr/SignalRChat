using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class UserCreatedDomainNotificationHandler : IDomainNotificationHandler<UserCreatedDomainNotification>
    {
        public Task Handle(UserCreatedDomainNotification notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
