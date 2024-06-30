using Domain.SeedWork;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;
using Infrastructure.Outbox;
using Newtonsoft.Json;

namespace Infrastructure.DomainEventsDispatching
{
    internal class DomainEventsDispatcher
    {
        private readonly DomainEventsAccessor _domainEventsAccessor;
        private readonly DomainEventsMapper _mapper;
        private readonly IOutbox _outbox;

        internal DomainEventsDispatcher(DomainEventsAccessor domainEventsAccessor, DomainEventsMapper mapper, 
            IOutbox outbox)
        {
            _domainEventsAccessor = domainEventsAccessor;
            _mapper = mapper;
            _outbox = outbox;
        }

        public void DispatchDomainEvents()
        {
            List<IDomainEvent> domainEvents = _domainEventsAccessor.GetAllDomainEvents();

            _domainEventsAccessor.ClearAllDomainEvents();

            foreach (var domainEvent in domainEvents)
            {
                Type notificationType = domainEvent.GetNotificationType();

                string json = JsonConvert.SerializeObject(Activator.CreateInstance(notificationType, [domainEvent]));

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
