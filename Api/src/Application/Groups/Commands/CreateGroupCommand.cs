using Application.Cqrs.Commands;

namespace Application.Groups.Commands
{
    public sealed class CreateGroupCommand(string name, Guid userId) : ICommand
    {
        public string Name { get; } = name;

        public Guid UserId { get; } = userId;
    }
}
