using Domain.SeedWork;

namespace Infrastructure.Data.DomainEventsDispatching
{
    public class DomainEventsAccessor(AppContext appContext)
    {
        private readonly AppContext _appContext = appContext;

        public List<IDomainEvent> GetAllDomainEvents()
        {
            var entities = GetEntities();

            return entities.SelectMany(e => e.DomainEvents).ToList();
        }

        public void ClearAllDomainEvents()
        {
            var entities = GetEntities();

            foreach (Entity entity in entities)
                entity.ClearDomainEvents();
        }

        private IEnumerable<Entity> GetEntities()
        {
            return _appContext.ChangeTracker.Entries<Entity>()
               .Where(e => e.Entity.DomainEvents != null && e.Entity.DomainEvents.Any())
               .Select(e => e.Entity);
        }
    }
}
