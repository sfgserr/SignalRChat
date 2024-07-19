using Application.Sessions.Commands.NotifyMarkPlaced;
using Domain.Sessions.Events;
using Infrastructure.DomainEventsDispatching.MediatR.Handlers.Abstractions;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class MarkPlacedEnqueueNotifyUserDomainNotificationHandler :
        IDomainNotificationHandler<MarkPlacedDomainNotification>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        internal MarkPlacedEnqueueNotifyUserDomainNotificationHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Handle(MarkPlacedDomainNotification notification, CancellationToken cancellationToken)
        {
            MarkPlacedDomainEvent @event = notification.DomainEvent;

            await _commandsScheduler.EnqueueAsync(new NotifyMarkPlacedCommand(
                Guid.NewGuid(),
                @event.ReceivingUserId,
                @event.Mark));
        }
    }
}
