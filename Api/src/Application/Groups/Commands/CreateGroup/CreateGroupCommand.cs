using Application.Cqrs.Commands;

namespace Application.Groups.Commands.CreateGroup
{
    public sealed class CreateGroupCommand(string name, Guid userId) : ICommand
    {
        public string Name { get; } = name;

        public Guid UserId { get; } = userId;
    }
}
