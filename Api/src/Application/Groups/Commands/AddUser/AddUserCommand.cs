using Application.Cqrs.Commands;

namespace Application.Groups.Commands.AddUser
{
    public class AddUserCommand(Guid userId, Guid groupId) : ICommand
    {
        public Guid UserId { get; } = userId;

        public Guid GroupId { get; } = groupId;
    }
}
