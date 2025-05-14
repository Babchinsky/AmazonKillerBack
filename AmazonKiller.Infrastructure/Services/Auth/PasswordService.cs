using AmazonKiller.Application.Interfaces.Auth;

namespace AmazonKiller.Infrastructure.Services.Auth;

public class PasswordService : IPasswordService
{
    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}