using Application.Contracts;
using Application.Cqrs.Commands;

namespace Application.Sessions.Commands.NotifySessionCreated
{
    internal class NotifySessionCreatedCommandHandler : ICommandHandler<NotifySessionCreatedCommand>
    {
        private readonly ISender _sender;

        internal NotifySessionCreatedCommandHandler(ISender sender)
        {
            _sender = sender;
        }

        public async Task Handle(NotifySessionCreatedCommand command)
        {
            await _sender.Send(command.SessionId, command.CrossUserId, command.NoughtUserId);
        }
    }
}
