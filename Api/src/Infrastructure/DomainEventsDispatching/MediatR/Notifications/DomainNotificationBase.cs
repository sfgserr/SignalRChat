using Domain.SeedWork;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class DomainNotificationBase<T> : IDomainNotificaiton where T : IDomainEvent
    {
        public DomainNotificationBase(T domainEvent) 
        {
            Id = domainEvent.Id;
            DomainEvent = domainEvent;
        }

        public Guid Id { get; }

        public T DomainEvent { get; }
    }
}
