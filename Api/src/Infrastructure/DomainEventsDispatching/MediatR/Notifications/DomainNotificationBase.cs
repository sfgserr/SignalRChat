
namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal abstract class DomainNotificationBase : IDomainNotificaiton
    {
        protected DomainNotificationBase(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
