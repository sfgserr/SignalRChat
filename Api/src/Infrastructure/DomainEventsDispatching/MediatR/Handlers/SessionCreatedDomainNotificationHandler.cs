using Application.Sessions.Commands.NotifySessionCreated;
using Domain.Sessions.Events;
using Infrastructure.DomainEventsDispatching.MediatR.Handlers.Abstractions;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class SessionCreatedDomainNotificationHandler : IDomainNotificationHandler<SessionCreatedDomainNotification>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        internal SessionCreatedDomainNotificationHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Handle(SessionCreatedDomainNotification notification, CancellationToken cancellationToken)
        {
            SessionCreatedDomainEvent @event = notification.DomainEvent;

            await _commandsScheduler.EnqueueAsync(new NotifySessionCreatedCommand(
                Guid.NewGuid(),
                @event.SessionId,
                @event.CrossUserId,
                @event.NoughtUserId));
        }
    }
}
