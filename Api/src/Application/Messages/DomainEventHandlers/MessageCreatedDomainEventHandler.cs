using Application.Contracts;
using Domain.Groups;
using Domain.Messages.Events;
using Domain.Users;

namespace Application.Messages.DomainEventHandlers
{
    public class MessageCreatedDomainEventHandler(IUserRepository userRepository, IGroupRepository groupRepository, 
        IEmailService emailService) : IDomainEventHandler<MessageCreatedDomainEvent>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IGroupRepository _groupRepository = groupRepository;
        private readonly IEmailService _emailService = emailService;

        public async Task Handle(MessageCreatedDomainEvent domainEvent)
        {
            Group group = await _groupRepository.Get(domainEvent.GroupId);

            foreach(UserId id in domainEvent.Users)
            {
                if (id != domainEvent.SenderId)
                {
                    User user = await _userRepository.Get(id);

                    await _emailService.Send(
                        user.Login,
                        $"{domainEvent.Created.ToShortTimeString()}:New message at {group.Name}");
                }
            }
        }
    }
}
