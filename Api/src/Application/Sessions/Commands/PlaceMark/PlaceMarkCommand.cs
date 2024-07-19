using Application.Cqrs.Commands;
using Domain.Sessions;

namespace Application.Sessions.Commands.PlaceMark
{
    public class PlaceMarkCommand(Guid sessionId, int index, Mark mark) : ICommand
    {
        public Guid SessionId { get; } = sessionId;

        public int Index { get; } = index;

        public Mark Mark { get; } = mark;
    }
}
