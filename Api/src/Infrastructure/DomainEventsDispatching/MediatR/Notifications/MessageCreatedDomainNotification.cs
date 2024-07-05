using Domain.Messages.Events;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class MessageCreatedDomainNotification : DomainNotificationBase<MessageCreatedDomainEvent>
    {
        public MessageCreatedDomainNotification(MessageCreatedDomainEvent domainEvent) : base(domainEvent)
        {

        }
    }
}
