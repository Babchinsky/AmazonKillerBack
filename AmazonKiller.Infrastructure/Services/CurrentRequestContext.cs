using AmazonKiller.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Infrastructure.Services;

public class CurrentRequestContext(IHttpContextAccessor accessor) : ICurrentRequestContext
{
    public string IpAddress =>
        accessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "unknown";

    public string UserAgent =>
        accessor.HttpContext?.Request.Headers.UserAgent.ToString() ?? "unknown";
}