using FluentValidation;

namespace AmazonKiller.Application.Validators.Common;

public static class EmailRules
{
    public static IRuleBuilderOptions<T, string> ValidEmail<T>(this IRuleBuilder<T, string> rule)
    {
        return rule
            .NotEmpty()
            .EmailAddress()
            .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
            .WithMessage("Invalid email format. Expected something like 'user@example.com'");
    }
}