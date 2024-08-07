﻿using FluentValidation;

namespace Application.Messages.Commands.CreateMessage
{
    internal class CreateMessageValidator : AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageValidator() 
        {
            RuleFor(c => c.ToGroupId).NotEmpty()
                .WithMessage("Group Id is empty");

            RuleFor(c => c.Body).NotEmpty()
                .WithMessage("Body is empty");
        }
    }
}
