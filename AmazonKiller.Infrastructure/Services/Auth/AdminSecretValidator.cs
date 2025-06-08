using AmazonKiller.Application.Interfaces.Services.Auth;
using AmazonKiller.Application.Options;
using Microsoft.Extensions.Options;

namespace AmazonKiller.Infrastructure.Services.Auth;

public class AdminSecretValidator(IOptions<AdminOptions> options) : IAdminSecretValidator
{
    private readonly string _secret = options.Value.RegistrationSecret;

    public bool IsValid(string secret) => secret == _secret;
}