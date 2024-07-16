using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class MessageCreatedDomainNotificationHandler : 
        IDomainNotificationHandler<MessageCreatedDomainNotification>
    {
        public Task Handle(MessageCreatedDomainNotification notification, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}
