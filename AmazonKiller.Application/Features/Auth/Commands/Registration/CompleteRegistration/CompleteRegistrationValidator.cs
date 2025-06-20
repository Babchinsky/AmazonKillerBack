﻿using AmazonKiller.Application.Validators.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Auth.Commands.Registration.CompleteRegistration;

public class CompleteRegistrationValidator : AbstractValidator<CompleteRegistrationCommand>
{
    public CompleteRegistrationValidator()
    {
        RuleFor(x => x.Email).ValidEmail();
        RuleFor(x => x.Code).Length(6);
        RuleFor(x => x.FirstName).FirstName();
        RuleFor(x => x.LastName).LastName();
    }
}