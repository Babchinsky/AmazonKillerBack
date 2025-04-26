namespace AmazonKiller.Application.Interfaces.Common;

public interface IVerificationEmailSender
{
    Task SendVerificationCodeAsync(string email, string subject, string code);
}