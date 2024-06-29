using Infrastructure.Data;
using Infrastructure.DomainEventsDispatching;
using Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Processing.Outbox
{
    internal class ProcessOutboxCommandHandler : IProcessOutboxCommandHandler
    {
        private readonly ApplicationContext _applicationContext;
        private readonly DomainEventsMapper _domainEventsMapper;

        internal ProcessOutboxCommandHandler(ApplicationContext applicationContext, 
            DomainEventsMapper domainEventsMapper)
        {
            _applicationContext = applicationContext;
            _domainEventsMapper = domainEventsMapper;
        }

        public async Task Handle(ProcessOutboxCommand command)
        {
            List<OutboxMessage> messages = await _applicationContext.OutboxMessages.ToListAsync();

            foreach (OutboxMessage message in messages)
            {
                await _domainEventsMapper.Handle(message.Type, message.Message);

                message.Proccessed = DateTime.Now;

                _applicationContext.OutboxMessages.Update(message);
            }
        }
    }
}
