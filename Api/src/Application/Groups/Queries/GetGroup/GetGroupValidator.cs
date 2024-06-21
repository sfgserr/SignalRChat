using FluentValidation;

namespace Application.Groups.Queries.GetGroup
{
    internal sealed class GetGroupValidator : AbstractValidator<GetGroupQuery>
    {
        public GetGroupValidator() 
        {
            RuleFor(c => c.GroupId).NotEmpty()
                .WithMessage("Group Id is empty");
        }
    }
}
