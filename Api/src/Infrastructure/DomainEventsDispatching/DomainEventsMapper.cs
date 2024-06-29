using Application.Contracts;
using Domain.SeedWork;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Infrastructure.DomainEventsDispatching
{
    internal class DomainEventsMapper
    {
        private readonly IServiceProvider _serviceProvider;

        internal DomainEventsMapper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Handle(string type, string message)
        {
            var eventType = Type.GetType(type)!;
            var @event = (IDomainEvent)JsonConvert.DeserializeObject(message, eventType)!;

            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(eventType);

            var handler = _serviceProvider.GetRequiredService(handlerType);

            if (handler != null)
            {
                var handleMethod = handlerType.GetMethod("Handle");

                await (Task)handleMethod!.Invoke(handler, [@event])!;
            }
        }
    }
}
