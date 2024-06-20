using Application.Cqrs.Commands;

namespace Application.Groups.Commands.RemoveUser
{
    public class RemoveUserCommand(Guid userId, Guid groupId) : ICommand
    {
        public Guid UserId { get; } = userId;

        public Guid GroupId { get; } = groupId;
    }
}
