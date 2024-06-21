using FluentValidation;

namespace Application.Messages.Commands.ReadMessage
{
    internal class ReadMessageValidator : AbstractValidator<ReadMessageCommand>
    {
        public ReadMessageValidator()
        {
            RuleFor(c => c.MessageId).NotEmpty()
                .WithMessage("Message Id is empty");
        }
    }
}
