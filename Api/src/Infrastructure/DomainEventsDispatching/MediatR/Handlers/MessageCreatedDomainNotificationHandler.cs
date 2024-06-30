using Application.Contracts;
using Domain.Messages.Events;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class MessageCreatedDomainNotificationHandler : 
        IDomainNotificationHandler<MessageCreatedDomainNotification>
    {
        private readonly IDomainEventHandler<MessageCreatedDomainEvent> _handler;

        internal MessageCreatedDomainNotificationHandler(IDomainEventHandler<MessageCreatedDomainEvent> handler)
        {
            _handler = handler;
        }

        public async Task Handle(MessageCreatedDomainNotification notification, CancellationToken token)
        {
            await _handler.Handle(notification.DomainEvent);
        }
    }
}
