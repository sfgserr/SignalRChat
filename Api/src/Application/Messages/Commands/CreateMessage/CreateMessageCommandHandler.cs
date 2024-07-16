using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Messages;
using Domain.Users;

namespace Application.Messages.Commands.CreateMessage
{
    internal class CreateMessageCommandHandler : ICommandHandler<CreateMessageCommand>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IUserContext _userContext;

        internal CreateMessageCommandHandler(
            IMessageRepository messageRepository, 
            IGroupRepository groupRepository, 
            IUserContext userContext)
        {
            _messageRepository = messageRepository;
            _groupRepository = groupRepository;
            _userContext = userContext;
        }

        public async Task Handle(CreateMessageCommand command)
        {
            Group group = await _groupRepository.Get(new GroupId(command.ToGroupId));

            Message message = group.CreateMessage(_userContext.Id, command.Body, command.Type);

            await _messageRepository.Add(message);
        }
    }
}
