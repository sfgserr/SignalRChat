using FluentValidation;

namespace Application.Groups.Queries.GetUserGroups
{
    internal class GetUserGroupsQueryValidator : AbstractValidator<GetUserGroupsQuery>
    {
        public GetUserGroupsQueryValidator()
        {
            RuleFor(q => q.UserId).NotEmpty()
                .WithMessage("User Id is empty");
        }
    }
}
