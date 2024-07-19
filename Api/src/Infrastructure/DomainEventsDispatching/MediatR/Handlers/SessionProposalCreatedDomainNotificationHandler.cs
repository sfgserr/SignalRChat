using Application.SessionProposals.Commands.SendProposal;
using Infrastructure.DomainEventsDispatching.MediatR.Handlers.Abstractions;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class SessionProposalCreatedDomainNotificationHandler :
        IDomainNotificationHandler<SessionProposalCreatedDomainNotification>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        internal SessionProposalCreatedDomainNotificationHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Handle(SessionProposalCreatedDomainNotification notification, CancellationToken cancellationToken)
        {
            await _commandsScheduler.EnqueueAsync(new SendProposalCommand(
                Guid.NewGuid(),
                notification.DomainEvent.SessionProposalId));
        }
    }
}
