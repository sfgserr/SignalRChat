using Application.Contracts;
using Domain.Groups.Events;
using Domain.Users;

namespace Application.Groups.DomainEventHandlers
{
    public class GroupCreatedDomainEventHandler(IEmailService emailService, IUserRepository userRepository) :
        IDomainEventHandler<GroupCreatedDomainEvent>
    {
        private readonly IEmailService _emailService = emailService;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task Handle(GroupCreatedDomainEvent domainEvent)
        {
            User user = await _userRepository.Get(domainEvent.AdminId);

            await _emailService.Send(user.Login, "You created group");
        }
    }
}
