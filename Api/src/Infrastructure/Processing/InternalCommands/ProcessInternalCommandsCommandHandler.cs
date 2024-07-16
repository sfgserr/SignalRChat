using Application.Cqrs.Commands;
using Infrastructure.Data;
using Infrastructure.InternalCommands;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Polly;

namespace Infrastructure.Processing.InternalCommands
{
    internal class ProcessInternalCommandsCommandHandler : ICommandHandler<ProcessInternalCommandsCommand>
    {
        private readonly ApplicationContext _applicationContext;

        internal ProcessInternalCommandsCommandHandler(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task Handle(ProcessInternalCommandsCommand command)
        {
            var internalCommands = await _applicationContext.InternalCommands.Where(i => i.ProcessedDate == null)
                .ToListAsync();

            var policy = Policy.Handle<Exception>()
                    .WaitAndRetryAsync(
                    [
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(2),
                        TimeSpan.FromSeconds(3),
                    ]);

            foreach (var internalCommand in internalCommands)
            {
                var result = await policy.ExecuteAndCaptureAsync(() => ProcessCommand(internalCommand));

                if (result.Outcome == OutcomeType.Failure)
                {
                    internalCommand.ProcessedDate = DateTime.Now;
                    internalCommand.Error = result.FinalException.Message;

                    _applicationContext.InternalCommands.Update(internalCommand);
                }
            }
        }

        private async Task ProcessCommand(InternalCommand internalCommand)
        {
            Type commandType = Assemblies.Application.GetType(internalCommand.Type)!;

            dynamic command = JsonConvert.DeserializeObject(internalCommand.Data, commandType);

            await CommandsExecutor.ExecuteCommandAsync(command!);
        }
    }
}
