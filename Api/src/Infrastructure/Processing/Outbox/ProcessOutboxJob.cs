using Application.Cqrs.Commands;
using Quartz;

namespace Infrastructure.Processing.Outbox
{
    internal class ProcessOutboxJob : IJob
    {
        private readonly ICommandHandler<ProcessOutboxCommand> _handler;

        internal ProcessOutboxJob(ICommandHandler<ProcessOutboxCommand> handler)
        {
            _handler = handler;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _handler.Handle(new());
        }
    }
}
