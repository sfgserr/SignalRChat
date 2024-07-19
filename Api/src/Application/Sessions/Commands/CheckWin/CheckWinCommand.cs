using Application.Cqrs.Commands;
using Domain.Sessions;

namespace Application.Sessions.Commands.CheckWin
{
    public class CheckWinCommand(Guid id, SessionId sessionId) : InternalCommandBase(id)
    {
        internal SessionId SessionId { get; } = sessionId;
    }
}
