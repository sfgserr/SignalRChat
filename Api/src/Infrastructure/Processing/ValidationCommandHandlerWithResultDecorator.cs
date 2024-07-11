using Application.Cqrs.Commands;
using Application.Exceptions;
using FluentValidation;

namespace Infrastructure.Processing
{
    internal class ValidationCommandHandlerWithResultDecorator<T, TResult> :
        ICommandHandlerWithResult<T, TResult> where T : ICommandWithResult<TResult>
    {
        private readonly IList<IValidator<T>> _validator;
        private readonly ICommandHandlerWithResult<T, TResult> _decorated;

        public ValidationCommandHandlerWithResultDecorator(IList<IValidator<T>> validator, 
            ICommandHandlerWithResult<T, TResult> decorated)
        {
            _validator = validator;
            _decorated = decorated;
        }

        public async Task<TResult> Handle(T command)
        {
            var errors = _validator
                    .Select(v => v.Validate(command))
                    .SelectMany(r => r.Errors);

            if (errors.Any())
            {
                throw new InvalidCommandException(errors.Select(e => e.ErrorMessage).ToList());
            }

            return await _decorated.Handle(command);
        }
    }
}
