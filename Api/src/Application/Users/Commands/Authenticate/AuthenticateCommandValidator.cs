using FluentValidation;

namespace Application.Users.Commands.Authenticate
{
    internal class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateCommandValidator() 
        {
            RuleFor(c => c.Login).NotEmpty()
                .WithMessage("Login is empty");

            RuleFor(c => c.Password).NotEmpty()
                .WithMessage("Password is empty");
        }
    }
}
