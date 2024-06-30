using Application.Cqrs.Commands;
using Serilog;

namespace Infrastructure.Processing
{
    internal class LoggingCommandHandlerDecorator<T> : 
        ICommandHandler<T> where T : ICommand
    {
        private readonly ILogger _logger;
        private readonly ICommandHandler<T> _decorated;

        internal LoggingCommandHandlerDecorator(ILogger logger, ICommandHandler<T> decorated)
        {
            _logger = logger;
            _decorated = decorated;
        }

        public async Task Handle(T command)
        {
            string commandName = command.GetType().Name;

            try
            {
                _logger.Information($"Command {commandName} executing");

                await _decorated.Handle(command);

                _logger.Information($"Command {commandName} processed successfull");
            }
            catch(Exception ex)
            {
                _logger.Error($"Command {commandName} failed with error {ex.Message}");
            }
        }
    }
}
