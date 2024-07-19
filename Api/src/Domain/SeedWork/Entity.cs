using Domain.Exceptions;

namespace Domain.SeedWork
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvents = [];

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
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
