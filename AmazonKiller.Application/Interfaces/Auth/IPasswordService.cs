namespace AmazonKiller.Application.Interfaces.Auth;

public interface IPasswordService
{
    bool VerifyPassword(string password, string hash);
}