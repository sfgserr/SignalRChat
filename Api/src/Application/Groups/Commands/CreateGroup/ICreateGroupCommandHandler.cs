using Application.Cqrs.Commands;

namespace Application.Groups.Commands.CreateGroup
{
    public interface ICreateGroupCommandHandler : ICommandHandler<CreateGroupCommand>
    {
    }
}
