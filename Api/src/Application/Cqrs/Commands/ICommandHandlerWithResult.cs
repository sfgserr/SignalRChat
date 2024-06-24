
namespace Application.Cqrs.Commands
{
    public interface ICommandHandlerWithResult<T, TResult> where T : ICommandWithResult<TResult>
    {
        Task<TResult> Handle(T command);
    }
}
