using Application.Cqrs.Commands;
using Domain.Users;

namespace Application.Sessions.Commands.NotifySessionEnded
{
    public class NotifySessionEndedCommand(Guid id, UserId crossUserId, UserId noughtUserId, UserId? winnerUserId) : 
        InternalCommandBase(id)
    {
        internal UserId CrossUserId { get; } = crossUserId;

        internal UserId NoughtUserId { get; } = noughtUserId;

        internal UserId? WinnerUserId { get; } = winnerUserId;
    }
}
