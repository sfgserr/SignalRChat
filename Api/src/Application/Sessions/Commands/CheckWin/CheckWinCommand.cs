using Application.Cqrs.Commands;

namespace Application.Sessions.Commands.CheckWin
{
    public class CheckWinCommand : InternalCommandBase
    {
        public CheckWinCommand(Guid id) : base(id)
        {
        }

        public int Index { get; }
    }
}
