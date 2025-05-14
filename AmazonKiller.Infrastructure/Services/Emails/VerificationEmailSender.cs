using System.Reflection;
using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Options;
using Microsoft.Extensions.Options;

namespace AmazonKiller.Infrastructure.Services.Emails;

public class VerificationEmailSender(IEmailSender emailSender, IOptions<EmailSettings> emailSettingsOptions)
    : IVerificationEmailSender
{
    private const string TemplatePath =
        "AmazonKiller.Infrastructure.Services.Emails.Templates.VerificationCodeTemplate.html";

    private readonly EmailSettings _settings = emailSettingsOptions.Value;

    public async Task SendVerificationCodeAsync(string email, string subject, string code)
    {
        var htmlTemplate = await LoadTemplateAsync();
        var htmlBody = htmlTemplate
            .Replace("{{code}}", code)
            .Replace("{{logoUrl}}", _settings.LogoUrl)
            .Replace("{{websiteUrl}}", _settings.WebsiteUrl)
            .Replace("{{year}}", DateTime.UtcNow.Year.ToString());

        await emailSender.SendEmailAsync(email, subject, htmlBody);
    }

    private static async Task<string> LoadTemplateAsync()
    {
        var assembly = Assembly.GetExecutingAssembly();
        await using var stream = assembly.GetManifestResourceStream(TemplatePath);

        if (stream == null)
            throw new InvalidOperationException(
                $"Embedded resource '{TemplatePath}' not found. Check if the file exists and Build Action is set to Embedded Resource.");

        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }
}