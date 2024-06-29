using Application.Cqrs.Commands;
using Domain.Messages;
using Domain.Users;

namespace Application.Messages.Commands.EditMessage
{
    public class EditMessageCommandHandler(IMessageRepository messageRepository, IUserContext userContext) :
        ICommandHandler<EditMessageCommand>
    {
        private readonly IMessageRepository _messageRepository = messageRepository;
        private readonly IUserContext _userContext = userContext;

        public async Task Handle(EditMessageCommand command)
        {
            Message messageToEdit = await _messageRepository.Get(new MessageId(command.MessageId));

            messageToEdit.Edit(_userContext.Id, command.Body);
        }
    }
}
