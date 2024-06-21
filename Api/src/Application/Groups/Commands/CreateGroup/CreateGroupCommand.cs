using Application.Cqrs.Commands;

namespace Application.Groups.Commands.CreateGroup
{
    public sealed class CreateGroupCommand(string name, string iconUri) : ICommand
    {
        public string Name { get; } = name;

        public string IconUri { get; } = iconUri;
    }
}
