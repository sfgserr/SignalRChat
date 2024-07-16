using Application.Cqrs.Commands;
using Domain.Messages;
using Domain.Users;

namespace Application.Messages.Commands.EditMessage
{
    internal class EditMessageCommandHandler : ICommandHandler<EditMessageCommand>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserContext _userContext;

        internal EditMessageCommandHandler(IMessageRepository messageRepository, IUserContext userContext)
        {
            _messageRepository = messageRepository;
            _userContext = userContext;
        }

        public async Task Handle(EditMessageCommand command)
        {
            Message messageToEdit = await _messageRepository.Get(new MessageId(command.MessageId));

            messageToEdit.Edit(_userContext.Id, command.Body);
        }
    }
}
