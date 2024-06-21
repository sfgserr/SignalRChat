using Application.Cqrs.Commands;

namespace Application.Groups.Commands.CreateGroup
{
    public sealed class CreateGroupCommand(string name) : ICommand
    {
        public string Name { get; } = name;
    }
}
