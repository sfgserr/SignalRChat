using FluentValidation;

namespace Application.Groups.Commands.RemoveUser
{
    internal class RemoveUserValidator : AbstractValidator<RemoveUserCommand>
    {
        public RemoveUserValidator()
        {
            RuleFor(c => c.UserId).NotEmpty()
                .WithMessage("User id is empty");

            RuleFor(c => c.GroupId).NotEmpty()
                .WithMessage("Group id is empty");
        }
    }
}
