using FluentValidation;

namespace Application.Groups.Commands.ChangeGroupName
{
    internal class ChangeGroupNameValidator : AbstractValidator<ChangeGroupNameCommand>
    {
        public ChangeGroupNameValidator() 
        {
            RuleFor(c => c.GroupId).NotEmpty()
                .WithMessage("Group Id is empty");

            RuleFor(c => c.Name).NotNull()
                .MaximumLength(4)
                .MaximumLength(16)
                .WithMessage("Length should be in range of 4 to 16");
        }
    }
}
