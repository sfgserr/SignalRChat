using Application.Cqrs.Commands;

namespace Application.Groups.Commands.ChangeGroupName
{
    public interface IChangeGroupNameCommandHandler : ICommandHandler<ChangeGroupNameCommand>
    {
    }
}
