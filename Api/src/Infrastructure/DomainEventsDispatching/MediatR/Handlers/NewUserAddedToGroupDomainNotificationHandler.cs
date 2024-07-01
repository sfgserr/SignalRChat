using Application.Contracts;
using Domain.Groups.Events;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class NewUserAddedToGroupDomainNotificationHandler : 
        IDomainNotificationHandler<NewUserAddedToGroupDomainNotification>
    {
        private readonly IDomainEventHandler<NewUserAddedToGroupDomainEvent> _handler;

        internal NewUserAddedToGroupDomainNotificationHandler(IDomainEventHandler<NewUserAddedToGroupDomainEvent> handler)
        {
            _handler = handler;
        }

        public async Task Handle(NewUserAddedToGroupDomainNotification notification, CancellationToken token)
        {
            await _handler.Handle(notification.DomainEvent);
        }
    }
}
