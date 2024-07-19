using Application.Sessions.Commands.CheckWin;
using Domain.Sessions.Events;
using Infrastructure.DomainEventsDispatching.MediatR.Handlers.Abstractions;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class MarkPlacedEnqueueCheckWinDomainNotificationHandler :
        IDomainNotificationHandler<MarkPlacedDomainNotification>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        internal MarkPlacedEnqueueCheckWinDomainNotificationHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Handle(MarkPlacedDomainNotification notification, CancellationToken cancellationToken)
        {
            MarkPlacedDomainEvent @event = notification.DomainEvent;

            await _commandsScheduler.EnqueueAsync(new CheckWinCommand(
                Guid.NewGuid(),
                @event.SessionId));
        }
    }
}
