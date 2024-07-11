using Quartz;

namespace Infrastructure.Processing.Outbox
{
    [DisallowConcurrentExecution]
    public class ProcessOutboxJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await CommandsExecutor.ExecuteCommandAsync(new ProcessOutboxCommand());
        }
    }
}
