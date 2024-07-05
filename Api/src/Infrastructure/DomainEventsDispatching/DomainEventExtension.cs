using Domain.SeedWork;

namespace Infrastructure.DomainEventsDispatching
{
    internal static class DomainEventExtension
    {
        public static Type GetNotificationType(this IDomainEvent @event)
        {
            string eventName = @event.GetType().Name;

            string notificationName = eventName.Replace("DomainEvent", "DomainNotification");

            var assembly = typeof(DomainEventsAccessor).Assembly;

            foreach (var type in assembly.GetTypes())
            {
                if (type.Name == notificationName)
                    return type;
            }

            return Type.GetType(notificationName)!;
        }
    }
}
