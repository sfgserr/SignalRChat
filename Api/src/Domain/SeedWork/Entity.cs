using Domain.Exceptions;

namespace Domain.SeedWork
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvents = [];

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents.Remove(eventItem);
        }

        protected void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken)
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
