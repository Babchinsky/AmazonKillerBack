using FluentValidation;

namespace AmazonKiller.Application.Validators.Common;

public static class PasswordRules
{
    public static IRuleBuilderOptions<T, string> SecurePassword<T>(this IRuleBuilder<T, string> rule) =>
        rule.NotEmpty()
            .MinimumLength(8)
            .Matches("[A-Z]").WithMessage("Must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Must contain at least one number.");
}