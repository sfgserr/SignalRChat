using FluentValidation;

namespace Application.Users.Commands.Authenticate
{
    public class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
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
