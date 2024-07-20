using Application.Cqrs.Commands;

namespace Application.Sessions.Commands.PlaceMark
{
    public class PlaceMarkCommand(int index, char mark) : ICommand
    {
        public int Index { get; } = index;

        public char Mark { get; } = mark;
    }
}
