using Application.Messages.Commands.SendMessage;
using Domain.Messages.Events;
using Infrastructure.DomainEventsDispatching.MediatR.Handlers.Abstractions;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class MessageCreatedEnqueueSendMessageHandler : IDomainNotificationHandler<MessageCreatedDomainNotification>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        internal MessageCreatedEnqueueSendMessageHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Handle(MessageCreatedDomainNotification notification, CancellationToken cancellationToken)
        {
            MessageCreatedDomainEvent @event = notification.DomainEvent;

            await _commandsScheduler.EnqueueAsync(new SendMessageCommand(
                @event.SenderId,
                @event.ToGroupId,
                @event.Body,
                @event.Type));
        }
    }
}
