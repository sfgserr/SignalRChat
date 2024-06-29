using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Messages;
using Domain.Users;

namespace Application.Messages.Commands.CreateMessage
{
    public sealed class CreateMessageCommandHandler(IMessageRepository messageRepository, 
        IGroupRepository groupRepository, IUserContext userContext) : ICommandHandler<CreateMessageCommand>
    {
        private readonly IMessageRepository _messageRepository = messageRepository;
        private readonly IGroupRepository _groupRepository = groupRepository;
        private readonly IUserContext _userContext = userContext;

        public async Task Handle(CreateMessageCommand command)
        {
            Group group = await _groupRepository.Get(new GroupId(command.ToGroupId));

            Message message = group.CreateMessage(_userContext.Id, command.Body, (MessageType)command.Type);

            await _messageRepository.Add(message);
        }
    }
}
