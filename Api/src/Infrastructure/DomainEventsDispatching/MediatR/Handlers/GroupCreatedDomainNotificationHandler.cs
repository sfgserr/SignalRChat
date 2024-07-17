using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class GroupCreatedDomainNotificationHandler : IDomainNotificationHandler<GroupCreatedDomainNotification>
    {
        public Task Handle(GroupCreatedDomainNotification notification, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}
