using AmazonKiller.Application.Interfaces.Auth;
using Microsoft.Extensions.Configuration;

namespace AmazonKiller.Infrastructure.Services.Auth;

public class AdminSecretValidator(IConfiguration config) : IAdminSecretValidator
{
    public bool IsValid(string secret)
    {
        return secret == config["Admin:RegistrationSecret"];
    }
}