using AmazonKiller.Application.Interfaces.Auth;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace AmazonKiller.Infrastructure.Services.Auth;

public class ResendEmailSender(IConfiguration cfg) : IEmailSender
{
    // private readonly string? _apiKey = cfg["Resend:ApiKey"];
    private readonly string? _apiKey = "re_eAdjgr9j_DF9Q9ciuv7PZkCoMhvDLvJjF";

    public async Task SendEmailAsync(string to, string subject, string htmlBody)
    {
        var client = new RestClient("https://api.resend.com/emails");
        var request = new RestRequest()
            .AddHeader("Authorization", $"Bearer {_apiKey}")
            .AddHeader("Content-Type", "application/json")
            .AddJsonBody(new
            {
                from = "onboarding@resend.dev", 
                to,
                subject,
                html = htmlBody
            });

        var response = await client.PostAsync(request);
        if (!response.IsSuccessful)
            throw new Exception($"Email sending failed: {response.Content}");
    }
}