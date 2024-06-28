
namespace Domain.SeedWork
{
    public abstract class DomainEventBase : IDomainEvent
    {
        public DomainEventBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}
