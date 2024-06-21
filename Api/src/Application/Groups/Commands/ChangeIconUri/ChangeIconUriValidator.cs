using FluentValidation;

namespace Application.Groups.Commands.ChangeIconUri
{
    internal class ChangeIconUriValidator : AbstractValidator<ChangeIconUriCommand>
    {
        public ChangeIconUriValidator() 
        {
            RuleFor(c => c.GroupId).NotEmpty()
                .WithMessage("Group Id is empty");

            RuleFor(c => c.IconUri).NotNull()
                .NotEmpty()
                .WithMessage("Icon uri is empty");
        }
    }
}
