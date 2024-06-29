using Infrastructure.Data;

namespace Infrastructure.Outbox
{
    internal class OutboxAccessor : IOutbox
    {
        private readonly ApplicationContext _applicationContext;

        internal OutboxAccessor(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Add(OutboxMessage message)
        {
            _applicationContext.OutboxMessages.Add(message);
        }
    }
}
