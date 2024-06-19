
namespace Domain.SeedWork
{
    public abstract class DomainEventBase : IDomainEvent
    {
        public DomainEventBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }
    }
}
