using System.Security.Claims;
using AmazonKiller.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Infrastructure.Services;

public class CurrentUserService(IHttpContextAccessor accessor) : ICurrentUserService
{
    public Guid UserId =>
        Guid.TryParse(accessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var id)
            ? id
            : throw new UnauthorizedAccessException("User ID not found in access token.");

    public string Email =>
        accessor.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value
        ?? throw new UnauthorizedAccessException("Email not found in access token.");

    public string Role =>
        accessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value
        ?? throw new UnauthorizedAccessException("Role not found in access token.");
}