using Application.Cqrs.Commands;
using Domain.Sessions;
using Domain.Users;

namespace Application.Sessions.Commands.NotifySessionCreated
{
    public class NotifySessionCreatedCommand(Guid id, SessionId sessionId, UserId crossUserId, UserId noughtUserId) : 
        InternalCommandBase(id)
    {
        internal SessionId SessionId { get; } = sessionId;

        internal UserId CrossUserId { get; } = crossUserId;

        internal UserId NoughtUserId { get; } = noughtUserId;
    }
}
