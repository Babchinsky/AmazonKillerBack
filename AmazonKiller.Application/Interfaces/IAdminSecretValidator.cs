namespace AmazonKiller.Application.Interfaces;

public interface IAdminSecretValidator
{
    bool IsValid(string secret);
}