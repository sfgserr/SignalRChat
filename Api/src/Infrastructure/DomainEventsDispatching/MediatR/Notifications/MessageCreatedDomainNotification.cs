using Domain.Messages.Events;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class MessageCreatedDomainNotification : DomainNotificationBase
    {
        internal MessageCreatedDomainNotification(MessageCreatedDomainEvent domainEvent) : base(domainEvent.Id)
        {
            DomainEvent = domainEvent;
        }

        public MessageCreatedDomainEvent DomainEvent { get; }
    }
}
