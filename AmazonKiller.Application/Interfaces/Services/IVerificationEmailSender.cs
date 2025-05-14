namespace AmazonKiller.Application.Interfaces.Services;

public interface IVerificationEmailSender
{
    Task SendVerificationCodeAsync(string email, string subject, string? code);
}