using Application.Contracts;
using Domain.SeedWork;
using Newtonsoft.Json;

namespace Infrastructure.DomainEventsDispatching
{
    internal class DomainEventsMapper(Dictionary<Type, object> domainEventsMappings)
    {
        private readonly Dictionary<Type, object> _domainEventsMappings = domainEventsMappings;

        public async Task Handle<T>(string type, string message) where T : IDomainEvent
        {
            
        }
    }
}
