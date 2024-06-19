using Application.Cqrs.Commands;
using Application.Exceptions;

namespace Application.Groups.Commands.AddUser
{
    internal sealed class AddUserValidationCommandHandler(ICommandHandler<AddUserCommand> commandHandler) : 
        ICommandHandler<AddUserCommand>
    {
        private readonly ICommandHandler<AddUserCommand> _commandHandler = commandHandler;

        public async Task Handle(AddUserCommand command)
        {
            List<string> errors = [];

            if (command.UserId == Guid.Empty)
            {
                errors.Add("UserId is empty");
            }

            if (command.GroupId == Guid.Empty)
            {
                errors.Add("GroupId is empty");
            }

            if (errors.Count > 0)
            {
                throw new InvalidCommandException(errors);
            }

            await _commandHandler.Handle(command);
        }
    }
}
