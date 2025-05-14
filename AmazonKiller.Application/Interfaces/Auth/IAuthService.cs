using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Features.Auth.Commands.Login;
using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces.Auth;

public interface IAuthService
{
    Task<string> GenerateJwtTokenAsync(User u);
    Task<string> GenerateRefreshTokenAsync(User user, string deviceId, string ip, string userAgent);
}