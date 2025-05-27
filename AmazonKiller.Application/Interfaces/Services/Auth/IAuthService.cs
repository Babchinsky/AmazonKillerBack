using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces.Services.Auth;

public interface IAuthService
{
    Task<string> GenerateJwtTokenAsync(User u);
    Task<string> GenerateRefreshTokenAsync(User user, string deviceId, string ip, string userAgent);
}