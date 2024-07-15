using Application.Contracts;
using Domain.Groups.Events;
using Domain.Users;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class NewUserAddedToGroupDomainNotificationHandler : 
        IDomainNotificationHandler<NewUserAddedToGroupDomainNotification>
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        internal NewUserAddedToGroupDomainNotificationHandler(IEmailService emailService, IUserRepository userRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
        }

        public async Task Handle(NewUserAddedToGroupDomainNotification notification, CancellationToken token)
        {
            NewUserAddedToGroupDomainEvent @event = notification.DomainEvent;

            User user = await _userRepository.Get(@event.UserId);

            await _emailService.Send(user.Login, $"You was added to Group:{@event.GroupId}");
        }
    }
}
