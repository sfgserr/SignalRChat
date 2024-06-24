using FluentValidation;

namespace Application.Messages.Queries.GetMessages
{
    internal class GetMessagesValidator : AbstractValidator<GetMessagesQuery>
    {
        public GetMessagesValidator() 
        {
            RuleFor(q => q.GroupId).NotEmpty()
                .WithMessage("Group Id is empty");
        }
    }
}
