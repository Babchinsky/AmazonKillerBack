namespace AmazonKiller.Application.Options;

public class StripeSettingsOptions
{
    public bool UseStripe { get; init; }
    public string? SecretKey { get; init; }
    public string? PublishableKey { get; init; }
}