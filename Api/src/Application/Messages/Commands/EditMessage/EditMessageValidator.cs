using FluentValidation;

namespace Application.Messages.Commands.EditMessage
{
    internal class EditMessageValidator : AbstractValidator<EditMessageCommand>
    {
        public EditMessageValidator() 
        {
            RuleFor(c => c.MessageId).NotEmpty()
                .WithMessage("Message Id is empty");

            RuleFor(c => c.Body).NotEmpty()
                .WithMessage("Body must be provided");
        }
    }
}
