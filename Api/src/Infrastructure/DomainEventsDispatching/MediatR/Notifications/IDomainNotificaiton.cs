using MediatR;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal interface IDomainNotificaiton : INotification
    {
        Guid Id { get; }
    }
}
