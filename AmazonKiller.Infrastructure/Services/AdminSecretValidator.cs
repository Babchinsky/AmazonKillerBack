using AmazonKiller.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AmazonKiller.Infrastructure.Services;

public class AdminSecretValidator(IConfiguration config) : IAdminSecretValidator
{
    public bool IsValid(string secret)
    {
        return secret == config["Admin:RegistrationSecret"];
    }
}