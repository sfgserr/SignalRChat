using Domain.SeedWork;
using Infrastructure.Outbox;
using Newtonsoft.Json;

namespace Infrastructure.DomainEventsDispatching
{
    internal class DomainEventsDispatcher(DomainEventsAccessor domainEventsAccessor, IOutbox outbox)
    {
        private readonly DomainEventsAccessor _domainEventsAccessor = domainEventsAccessor;
        private readonly IOutbox _outbox = outbox;

        public void DispatchDomainEvents()
        {
            List<IDomainEvent> domainEvents = _domainEventsAccessor.GetAllDomainEvents();

            _domainEventsAccessor.ClearAllDomainEvents();

            foreach (var domainEvent in domainEvents)
            {
                string json = JsonConvert.SerializeObject(domainEvent);

                OutboxMessage message = new(
                    domainEvent.Id,
                    domainEvent.GetType().Name,
                    json,
                    DateTime.Now);

                _outbox.Add(message);
            }
        }
    }
}
