
using Application.Cqrs.Commands;
using Domain.Sessions;
using Domain.Users;

namespace Application.Sessions.Commands.NotifyMarkPlaced
{
    public class NotifyMarkPlacedCommand(Guid id, UserId receivingUserId, Mark mark) : InternalCommandBase(id)
    {
        public UserId ReceivingUserId { get; } = receivingUserId;

        public Mark Mark { get; } = mark;
    }
}
