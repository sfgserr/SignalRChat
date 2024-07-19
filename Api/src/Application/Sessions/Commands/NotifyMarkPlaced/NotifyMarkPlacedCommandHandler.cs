using Application.Contracts;
using Application.Cqrs.Commands;

namespace Application.Sessions.Commands.NotifyMarkPlaced
{
    internal class NotifyMarkPlacedCommandHandler : ICommandHandler<NotifyMarkPlacedCommand>
    {
        private readonly ISender _sender;

        internal NotifyMarkPlacedCommandHandler(ISender sender)
        {
            _sender = sender;
        }

        public async Task Handle(NotifyMarkPlacedCommand command)
        {
            await _sender.Send(command.ReceivingUserId, command.Mark.Value);
        }
    }
}
