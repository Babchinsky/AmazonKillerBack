using Microsoft.AspNetCore.Mvc.Filters;

namespace AmazonKiller.WebApi.Filters;

public class EnrichWithClientInfoFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var http = context.HttpContext;
        var ip = http.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        var ua = http.Request.Headers.UserAgent.ToString();

        foreach (var arg in context.ActionArguments.Values)
        {
            var cmd = arg?.GetType();
            if (cmd?.GetProperty("IpAddress") is { CanWrite: true } ipProp)
                ipProp.SetValue(arg, ip);
            if (cmd?.GetProperty("UserAgent") is { CanWrite: true } uaProp)
                uaProp.SetValue(arg, ua);
        }

        await next();
    }
}