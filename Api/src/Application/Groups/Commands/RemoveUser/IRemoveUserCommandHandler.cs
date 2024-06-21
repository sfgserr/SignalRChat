using Application.Cqrs.Commands;

namespace Application.Groups.Commands.RemoveUser
{
    public interface IRemoveUserCommandHandler : ICommandHandler<RemoveUserCommand>
    {
    }
}
