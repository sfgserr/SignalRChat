using Application.Cqrs.Commands;

namespace Application.Sessions.Commands.PlaceMark
{
    public class PlaceMarkCommand(int index) : ICommand
    {
        public int Index { get; } = index;
    }
}
