using System.Security.Claims;
using AmazonKiller.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Infrastructure.Services;

public class CurrentUserService(IHttpContextAccessor accessor) : ICurrentUserService
{
    private HttpContext? HttpContext => accessor.HttpContext;

    public Guid UserId =>
        Guid.TryParse(HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var id)
            ? id
            : throw new UnauthorizedAccessException("User ID not found in access token.");
}