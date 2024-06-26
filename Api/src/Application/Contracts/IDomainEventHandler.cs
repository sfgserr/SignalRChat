using Domain.SeedWork;

namespace Application.Contracts
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        Task Handle(T domainEvent);
    }
}
