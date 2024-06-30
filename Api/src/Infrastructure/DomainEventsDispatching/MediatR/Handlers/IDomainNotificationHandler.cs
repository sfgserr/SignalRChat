using Infrastructure.DomainEventsDispatching.MediatR.Notifications;
using MediatR;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal interface IDomainNotificationHandler<T> : INotificationHandler<T> where T : IDomainNotificaiton
    {

    }
}
