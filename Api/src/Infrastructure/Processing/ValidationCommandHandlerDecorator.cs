using Application.Cqrs.Commands;
using Application.Exceptions;
using FluentValidation;

namespace Infrastructure.Processing
{
    internal class ValidationCommandHandlerDecorator<T>(List<IValidator<T>> validators, ICommandHandler<T> decorated) : 
        ICommandHandler<T> where T : ICommand
    {
        private readonly List<IValidator<T>> _validators = validators;
        private readonly ICommandHandler<T> _decorated = decorated;

        public async Task Handle(T command)
        {
            var errors = _validators.Select(v => v.Validate(command))
                .SelectMany(r => r.Errors)
                .Where(e => e != null)
                .ToList();

            if (errors.Any())
            {
                throw new InvalidCommandException(errors.Select(e => e.ErrorMessage).ToList());
            }

            await _decorated.Handle(command);
        }
    }
}
