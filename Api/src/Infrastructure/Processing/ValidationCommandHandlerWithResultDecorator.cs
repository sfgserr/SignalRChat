using Application.Cqrs.Commands;
using Application.Exceptions;
using FluentValidation;

namespace Infrastructure.Processing
{
    internal class ValidationCommandHandlerWithResultDecorator<T, TResult> :
        ICommandHandlerWithResult<T, TResult> where T : ICommandWithResult<TResult>
    {
        private readonly List<IValidator<T>> _validators;
        private readonly ICommandHandlerWithResult<T, TResult> _decorated;

        internal ValidationCommandHandlerWithResultDecorator(List<IValidator<T>> validators, 
            ICommandHandlerWithResult<T, TResult> decorated)
        {
            _validators = validators;
            _decorated = decorated;
        }

        public async Task<TResult> Handle(T command)
        {
            var errors = _validators.Select(v => v.Validate(command))
                .SelectMany(r => r.Errors)
                .Where(e => e != null)
                .ToList();

            if (errors.Any())
            {
                throw new InvalidCommandException(errors.Select(e => e.ErrorMessage).ToList());
            }

            return await _decorated.Handle(command);
        }
    }
}
