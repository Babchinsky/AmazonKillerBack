using System.Security.Claims;
using AmazonKiller.Application.Interfaces.Common;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Infrastructure.Services.Common;

public class CurrentUserService(IHttpContextAccessor accessor) : ICurrentUserService
{
    public Guid? UserId =>
        Guid.TryParse(accessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var id) ? id : null;

    public string? Email => accessor.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;
    public string? Role => accessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;
}