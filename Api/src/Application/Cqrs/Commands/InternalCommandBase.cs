
namespace Application.Cqrs.Commands
{
    public abstract class InternalCommandBase(Guid id) : ICommand
    {
        public Guid Id { get; } = id;
    }
}
