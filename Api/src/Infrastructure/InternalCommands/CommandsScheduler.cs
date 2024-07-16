using Application.Cqrs.Commands;
using Infrastructure.Data;
using Infrastructure.DomainEventsDispatching.MediatR.Handlers.Abstractions;
using Infrastructure.Serialization;
using Newtonsoft.Json;

namespace Infrastructure.InternalCommands
{
    internal class CommandsScheduler : ICommandsScheduler
    {
        private readonly ApplicationContext _applicationContext;

        internal CommandsScheduler(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task EnqueueAsync(ICommand command)
        {
            string type = command.GetType().Name;

            string json = JsonConvert.SerializeObject(command, new JsonSerializerSettings()
            {
                ContractResolver = new AllPropertiesContractResolver()
            });

            var internalCommand = new InternalCommand(Guid.NewGuid(), type, json);

            await _applicationContext.InternalCommands.AddAsync(internalCommand);
        }
    }
}
