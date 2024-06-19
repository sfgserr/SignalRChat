using Application.Cqrs.Commands;
using Application.Exceptions;

namespace Application.Groups.Commands
{
    public sealed class CreateGroupValidationCommandHandler(ICommandHandler<CreateGroupCommand> commandHandler) : 
        ICommandHandler<CreateGroupCommand>
    {
        private readonly ICommandHandler<CreateGroupCommand> _commandHandler = commandHandler;

        public async Task Handle(CreateGroupCommand command)
        {
            List<string> errors = [];

            if (command.UserId == Guid.Empty)
            {
                errors.Add("Guid is empty");
            }

            if (errors.Count > 0)
            {
                throw new InvalidCommandException(errors);
            }

            await _commandHandler.Handle(command);
        }
    }
}
