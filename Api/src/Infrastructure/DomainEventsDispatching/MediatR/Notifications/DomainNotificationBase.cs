using Domain.SeedWork;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal abstract class DomainNotificationBase<T> : IDomainNotificaiton where T : IDomainEvent
    {
        protected DomainNotificationBase(T domainEvent) 
        {
            Id = domainEvent.Id;
            DomainEvent = domainEvent;
        }

        public Guid Id { get; }

        public T DomainEvent { get; }
    }
}
