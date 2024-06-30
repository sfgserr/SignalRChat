using Domain.SeedWork;

namespace Infrastructure.DomainEventsDispatching
{
    internal static class DomainEventExtension
    {
        public static Type GetNotificationType(this IDomainEvent @event)
        {
            string eventName = @event.GetType().Name;

            string notificationName = eventName.Replace("DomainEvent", "DomainNotification");

            return Type.GetType(notificationName)!;
        }
    }
}
