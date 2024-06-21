using FluentValidation;

namespace Application.Groups.Commands.CreateGroup
{
    internal sealed class CreateGroupValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupValidator()
        {
            RuleFor(c => c.Name).MinimumLength(4)
                .MaximumLength(16)
                .NotEmpty()
                .NotNull()
                .WithMessage("Invalid name. Length should be in the range of 4 to 16");
        }
    }
}
