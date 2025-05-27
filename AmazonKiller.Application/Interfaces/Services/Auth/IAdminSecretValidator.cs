namespace AmazonKiller.Application.Interfaces.Services.Auth;

public interface IAdminSecretValidator
{
    bool IsValid(string secret);
}