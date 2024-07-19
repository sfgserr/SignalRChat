using Application.Cqrs.Commands;

namespace Application.Sessions.Commands.PlaceMark
{
    public class PlaceMarkCommand(Guid sessionId, int index, char mark) : ICommand
    {
        public Guid SessionId { get; } = sessionId;

        public int Index { get; } = index;

        public char Mark { get; } = mark;
    }
}
