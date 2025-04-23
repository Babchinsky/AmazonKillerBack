using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Features.Auth.Commands.Login;
using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces;

public interface IAuthService
{
    Task<AuthTokensDto> LoginAsync(LoginUserCommand cmd);
    Task<string> GenerateJwtTokenAsync(User u);
    Task<string> GenerateRefreshTokenAsync(User u);
}