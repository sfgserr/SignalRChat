using Application.Sessions.Commands.NotifySessionEnded;
using Domain.Sessions.Events;
using Infrastructure.DomainEventsDispatching.MediatR.Handlers.Abstractions;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class SessionEndedDomainNotificationHandler : IDomainNotificationHandler<SessionEndedDomainNotification>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        internal SessionEndedDomainNotificationHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Handle(SessionEndedDomainNotification notification, CancellationToken cancellationToken)
        {
            SessionEndedDomainEvent @event = notification.DomainEvent;

            await _commandsScheduler.EnqueueAsync(new NotifySessionEndedCommand(
                Guid.NewGuid(),
                @event.CrossUserId,
                @event.NoughtUserId,
                @event.WinnerUserId));
        }
    }
}
