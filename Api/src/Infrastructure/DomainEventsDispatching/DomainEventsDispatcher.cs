using Domain.SeedWork;
using Infrastructure.Outbox;
using Newtonsoft.Json;

namespace Infrastructure.DomainEventsDispatching
{
    internal class DomainEventsDispatcher
    {
        private readonly DomainEventsAccessor _domainEventsAccessor;
        private readonly IOutbox _outbox;

        internal DomainEventsDispatcher(DomainEventsAccessor domainEventsAccessor, IOutbox outbox)
        {
            _domainEventsAccessor = domainEventsAccessor;
            _outbox = outbox;
        }

        public void DispatchDomainEvents()
        {
            List<IDomainEvent> domainEvents = _domainEventsAccessor.GetAllDomainEvents();

            _domainEventsAccessor.ClearAllDomainEvents();

            foreach (var domainEvent in domainEvents)
            {
                Type notificationType = domainEvent.GetNotificationType();

                string json = JsonConvert.SerializeObject(Activator.CreateInstance(notificationType, domainEvent));

                OutboxMessage message = new(
                    domainEvent.Id,
                    notificationType.Name,
                    json,
                    DateTime.Now);

                _outbox.Add(message);
            }
        }
    }
}
