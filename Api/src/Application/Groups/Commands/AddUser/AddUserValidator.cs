using FluentValidation;

namespace Application.Groups.Commands.AddUser
{
    internal sealed class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator() 
        {
            RuleFor(c => c.UserId).NotEmpty()
                .WithMessage("User Id is empty");

            RuleFor(c => c.GroupId).NotEmpty()
                .WithMessage("Group Id is empty");
        }
    }
}
