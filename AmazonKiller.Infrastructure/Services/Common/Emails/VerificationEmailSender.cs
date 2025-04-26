using System.Reflection;
using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Application.Interfaces.Common;

namespace AmazonKiller.Infrastructure.Services.Common.Emails;

public class VerificationEmailSender(IEmailSender emailSender) : IVerificationEmailSender
{
    private const string TemplatePath =
        "AmazonKiller.Infrastructure.Services.Common.Emails.Templates.VerificationCodeTemplate.html";

    private const string LogoUrl = "https://i.imgur.com/580gOlL.png";
    private const string WebsiteUrl = "http://localhost:8080/scalar/";

    public async Task SendVerificationCodeAsync(string email, string subject, string code)
    {
        var htmlTemplate = await LoadTemplateAsync();
        var htmlBody = htmlTemplate
            .Replace("{{code}}", code)
            .Replace("{{logoUrl}}", LogoUrl)
            .Replace("{{websiteUrl}}", WebsiteUrl)
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