using System.Net;
using System.Net.Mail;
using AmazonKiller.Application.Interfaces.Services.Auth;
using AmazonKiller.Application.Options;
using Microsoft.Extensions.Options;

namespace AmazonKiller.Infrastructure.Services.Auth;

public class GmailEmailSender(IOptions<GmailSettings> options) : IEmailSender
{
    private readonly GmailSettings _settings = options.Value;

    public async Task SendEmailAsync(string to, string subject, string htmlBody)
    {
        var smtp = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(_settings.From, _settings.AppPassword)
        };

        var message = new MailMessage(_settings.From, to, subject, htmlBody)
        {
            IsBodyHtml = true
        };

        await smtp.SendMailAsync(message);
    }
}