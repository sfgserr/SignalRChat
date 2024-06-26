using Application.Contracts;
using Domain.Groups.Events;
using Domain.Users;

namespace Application.Groups.DomainEventHandlers
{
    public class NewUserAddedToGroupDomainEventHandler(IUserRepository userRepository, IEmailService emailService) : 
        IDomainEventHandler<NewUserAddedToGroupDomainEvent>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IEmailService _emailService = emailService;

        public async Task Handle(NewUserAddedToGroupDomainEvent domainEvent)
        {
            User user = await _userRepository.Get(domainEvent.UserId);

            await _emailService.Send(user.Login, "New user added to group");
        }
    }
}
