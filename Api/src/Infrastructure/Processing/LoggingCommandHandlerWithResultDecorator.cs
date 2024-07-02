using Application.Cqrs.Commands;
using Serilog;

namespace Infrastructure.Processing
{
    internal class LoggingCommandHandlerWithResultDecorator<T, TResult> : 
        ICommandHandlerWithResult<T, TResult> where T : ICommandWithResult<TResult>
    {
        private readonly ILogger _logger;
        private readonly ICommandHandlerWithResult<T, TResult> _decorated;

        internal LoggingCommandHandlerWithResultDecorator(ILogger logger, ICommandHandlerWithResult<T, TResult> decorated)
        {
            _logger = logger;
            _decorated = decorated;
        }

        public async Task<TResult> Handle(T command)
        {
            if (command is IRecurringCommand)
            {
                return await _decorated.Handle(command); ;
            }

            string commandName = command.GetType().Name;

            try
            {
                _logger.Information($"Command with result({commandName}) is being executed");

                TResult result = await _decorated.Handle(command);

                _logger.Information($"{commandName} has been executed successfully");

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error($"Command {commandName} failed with error {ex.Message}");
                throw;
            }
        }
    }
}
