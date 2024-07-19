﻿using Domain.Sessions;
using FluentValidation;

namespace Application.Sessions.Commands.PlaceMark
{
    internal class PlaceMarkValidator : AbstractValidator<PlaceMarkCommand>
    {
        public PlaceMarkValidator() 
        {
            RuleFor(p => Mark.Parse(p.Mark))
                .NotNull()
                .WithMessage("Only available marks are X and O");
        }
    }
}
