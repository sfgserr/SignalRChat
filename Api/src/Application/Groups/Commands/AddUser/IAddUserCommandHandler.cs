using Application.Cqrs.Commands;

namespace Application.Groups.Commands.AddUser
{
    public interface IAddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
    }
}
