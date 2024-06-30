using Application.Groups.DomainEventHandlers;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class GroupCreatedDomainNotificationHandler : IDomainNotificationHandler<GroupCreatedDomainNotification>
    {
        private readonly GroupCreatedDomainEventHandler _handler;

        internal GroupCreatedDomainNotificationHandler(GroupCreatedDomainEventHandler handler)
        {
            _handler = handler;
        }

        public async Task Handle(GroupCreatedDomainNotification notification, CancellationToken token)
        {
            await _handler.Handle(notification.DomainEvent);
        }
    }
}
