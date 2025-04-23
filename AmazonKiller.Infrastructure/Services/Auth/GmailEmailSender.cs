using System.Net;
using System.Net.Mail;
using AmazonKiller.Application.Interfaces.Auth;
using Microsoft.Extensions.Configuration;

namespace AmazonKiller.Infrastructure.Services.Auth;

public class GmailEmailSender(IConfiguration cfg) : IEmailSender
{
    private readonly string? _from = cfg["Gmail:From"];
    private readonly string? _appPassword = cfg["Gmail:AppPassword"];

    public async Task SendEmailAsync(string to, string subject, string htmlBody)
    {
        var smtp = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(_from, _appPassword)
        };

        if (_from != null)
        {
            var message = new MailMessage(_from, to, subject, htmlBody)
            {
                IsBodyHtml = true
            };

            await smtp.SendMailAsync(message);
        }
    }
}