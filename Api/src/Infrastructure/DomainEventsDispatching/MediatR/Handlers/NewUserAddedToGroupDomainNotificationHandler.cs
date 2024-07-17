using Application.Groups.Commands.SendEmailToAddedUser;
using Infrastructure.DomainEventsDispatching.MediatR.Handlers.Abstractions;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class NewUserAddedToGroupDomainNotificationHandler : 
        IDomainNotificationHandler<NewUserAddedToGroupDomainNotification>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        internal NewUserAddedToGroupDomainNotificationHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Handle(NewUserAddedToGroupDomainNotification notification, CancellationToken token)
        {
            await _commandsScheduler.EnqueueAsync(new SendEmailToAddedUserCommand(
                Guid.NewGuid(),
                notification.DomainEvent.UserId,
                notification.DomainEvent.GroupId));
        }
    }
}
