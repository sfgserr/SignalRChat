using FluentValidation;

namespace Application.Users.Commands.Register
{
    internal class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator() 
        {
            RuleFor(c => c.Login).NotEmpty()
                .WithMessage("Login is empty");

            RuleFor(c => c.Password).NotEmpty()
                .WithMessage("Password is empty");
        }
    }
}
