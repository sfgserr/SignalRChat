using Application.Contracts;
using Application.Cqrs.Commands;
using Domain.Users;

namespace Application.Sessions.Commands.NotifySessionEnded
{
    internal class NotifySessionEndedCommandHandler(ISender sender) : ICommandHandler<NotifySessionEndedCommand>
    {
        private readonly ISender _sender = sender;

        public async Task Handle(NotifySessionEndedCommand command)
        {
            if (command.WinnerUserId is not null)
            {
                await _sender.Send("Session is ended. You won", command.WinnerUserId);

                UserId losedUserId = !command.WinnerUserId.Equals(command.CrossUserId) ? 
                    command.CrossUserId : command.NoughtUserId;

                await _sender.Send("Session is ended. You lose", losedUserId);
            }

            await _sender.Send("Session is ended with draw", command.CrossUserId);
            await _sender.Send("Session is ended with draw", command.NoughtUserId);
        }
    }
}
