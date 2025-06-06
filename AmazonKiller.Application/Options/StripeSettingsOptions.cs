namespace AmazonKiller.Application.Options;

public class StripeSettingsOptions
{
    public string SecretKey { get; init; } = string.Empty;
    public string PublishableKey { get; init; } = string.Empty;
}