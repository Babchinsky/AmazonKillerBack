namespace AmazonKiller.Application.Options;

public class EmailSettings
{
    public string LogoUrl { get; init; } = string.Empty;
    public string WebsiteUrl { get; init; } = string.Empty;
    public bool SendVerificationCode { get; init; } = true;
}