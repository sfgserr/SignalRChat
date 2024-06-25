using Application.Cqrs.Commands;

namespace Application.Users.Commands.Register
{
    public interface IRegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
    }
}
