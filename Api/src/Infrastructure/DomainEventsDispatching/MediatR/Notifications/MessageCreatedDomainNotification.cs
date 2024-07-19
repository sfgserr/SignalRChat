using Domain.Messages.Events;
using Newtonsoft.Json;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class MessageCreatedDomainNotification : DomainNotificationBase<MessageCreatedDomainEvent>
    {
        [JsonConstructor]
        public MessageCreatedDomainNotification(MessageCreatedDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
