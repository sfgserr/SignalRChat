using Application.Cqrs.Commands;
using Infrastructure.Data;
using Infrastructure.DomainEventsDispatching;
using Infrastructure.DomainEventsDispatching.MediatR.Notifications;
using Infrastructure.Outbox;
using Infrastructure.Serialization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infrastructure.Processing.Outbox
{
    internal class ProcessOutboxCommandHandler : ICommandHandler<ProcessOutboxCommand>
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IMediator _mediator;
        private readonly DomainEventsMapper _mapper;

        public ProcessOutboxCommandHandler(ApplicationContext applicationContext, IMediator mediator, 
            DomainEventsMapper mapper)
        {
            _applicationContext = applicationContext;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Handle(ProcessOutboxCommand command)
        {
            List<OutboxMessage> messages = await _applicationContext.OutboxMessages.ToListAsync();

            foreach (OutboxMessage message in messages)
            {
                var notification = JsonConvert.DeserializeObject(message.Message, _mapper.GetType(message.Type)) 
                    as IDomainNotificaiton;

                await _mediator.Publish(notification!);

                message.Proccessed = DateTime.Now;

                _applicationContext.OutboxMessages.Update(message);
            }
        }
    }
}
