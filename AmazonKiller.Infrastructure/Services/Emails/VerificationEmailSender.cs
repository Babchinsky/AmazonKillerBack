using System.Reflection;
using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Options;
using AmazonKiller.Domain.Entities.Users;
using Microsoft.Extensions.Options;

namespace AmazonKiller.Infrastructure.Services.Emails;

public class VerificationEmailSender(
    IEmailSender emailSender,
    IEmailVerificationRepository verificationRepository,
    IOptions<EmailSettings> emailSettingsOptions)
    : IVerificationEmailSender
{
    private const string TemplatePath =
        "AmazonKiller.Infrastructure.Services.Emails.Templates.VerificationCodeTemplate.html";

    private readonly EmailSettings _settings = emailSettingsOptions.Value;

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

    private async Task SendVerificationCodeAsync(string email, string subject, string? code)
    {
        if (!_settings.SendVerificationCode)
            return;

        var htmlTemplate = await LoadTemplateAsync();
        var htmlBody = htmlTemplate
            .Replace("{{code}}", code)
            .Replace("{{logoUrl}}", _settings.LogoUrl)
            .Replace("{{websiteUrl}}", _settings.WebsiteUrl)
            .Replace("{{year}}", DateTime.UtcNow.Year.ToString());

        await emailSender.SendEmailAsync(email, subject, htmlBody);
    }

    public async Task<string> CreateAndSendAsync(
        string email,
        string subject,
        VerificationType type,
        string? tempHash,
        Guid? userId,
        CancellationToken ct)
    {
        var code = await verificationRepository.CreateAndSaveCodeAsync(email, type, tempHash, userId, ct);
        await SendVerificationCodeAsync(email, subject, code);
        return code;
    }
}