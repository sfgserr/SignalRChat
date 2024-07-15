using Application.Contracts;
using Domain.Users;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class GroupCreatedDomainNotificationHandler : IDomainNotificationHandler<GroupCreatedDomainNotification>
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        internal GroupCreatedDomainNotificationHandler(IEmailService emailService, IUserRepository userRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
        }

        public async Task Handle(GroupCreatedDomainNotification notification, CancellationToken token)
        {
            User user = await _userRepository.Get(notification.DomainEvent.AdminId);

            await _emailService.Send(user.Login, "You created group");
        }
    }
}
