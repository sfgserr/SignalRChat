using Application.Sessions.Commands.CreateSession;
using Domain.SessionProposals.Events;
using Infrastructure.DomainEventsDispatching.MediatR.Handlers.Abstractions;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class SessionProposalAcceptedDomainNotificationHandler : IDomainNotificationHandler<SessionProposalAcceptedDomainNotification>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        internal SessionProposalAcceptedDomainNotificationHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Handle(SessionProposalAcceptedDomainNotification notification, CancellationToken cancellationToken)
        {
            SessionProposalAcceptedDomainEvent @event = notification.DomainEvent;

            await _commandsScheduler.EnqueueAsync(new CreateSessionCommand(
                Guid.NewGuid(),
                @event.ProposingUserId,
                @event.ProposedUserId));
        }
    }
}
