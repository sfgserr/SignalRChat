using Domain.Messages.Events;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class MessageCreatedDomainNotification : DomainNotificationBase<MessageCreatedDomainEvent>
    {
        internal MessageCreatedDomainNotification(MessageCreatedDomainEvent domainEvent) : base(domainEvent)
        {

        }
    }
}
