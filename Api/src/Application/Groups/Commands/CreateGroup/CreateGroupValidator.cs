﻿using FluentValidation;

namespace Application.Groups.Commands.CreateGroup
{
    public class CreateGroupValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupValidator()
        {
            RuleFor(c => c.Name).NotNull()
                .MinimumLength(4)
                .MaximumLength(16)
                .WithMessage("Length should be in range of 4 to 16");

            RuleFor(c => c.IconUri)
                .NotNull()
                .NotEmpty();
        }
    }
}
