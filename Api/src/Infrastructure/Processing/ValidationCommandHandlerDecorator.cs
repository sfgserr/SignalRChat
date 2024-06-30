using Application.Cqrs.Commands;
using Application.Exceptions;
using FluentValidation;

namespace Infrastructure.Processing
{
    internal class ValidationCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly List<IValidator<T>> _validators;
        private readonly ICommandHandler<T> _decorated;

        internal ValidationCommandHandlerDecorator(List<IValidator<T>> validators, ICommandHandler<T> decorated)
        {
            _validators = validators;
            _decorated = decorated;
        }

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
