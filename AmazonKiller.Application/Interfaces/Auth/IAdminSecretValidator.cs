namespace AmazonKiller.Application.Interfaces.Auth;

public interface IAdminSecretValidator
{
    bool IsValid(string secret);
}