using Application.Contracts;
using Domain.Messages.Events;
using Domain.Users;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers
{
    internal class MessageCreatedDomainNotificationHandler : 
        IDomainNotificationHandler<MessageCreatedDomainNotification>
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        internal MessageCreatedDomainNotificationHandler(IEmailService emailService, IUserRepository userRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
        }

        public async Task Handle(MessageCreatedDomainNotification notification, CancellationToken token)
        {
            MessageCreatedDomainEvent @event = notification.DomainEvent;

            User user = await _userRepository.Get(@event.SenderId);

            await _emailService.Send(user.Login, $"Successfully send message to Group:{@event.GroupId}");
        }
    }
}
