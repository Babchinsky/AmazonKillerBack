﻿using FluentValidation;

namespace AmazonKiller.Application.Features.Profile.Commands.ChangeEmail.ConfirmEmailChange;

public class ConfirmEmailChangeValidator : AbstractValidator<ConfirmEmailChangeCommand>
{
    public ConfirmEmailChangeValidator()
    {
        RuleFor(x => x.Code).Length(6).WithMessage("Code must be 6 digits");
    }
}