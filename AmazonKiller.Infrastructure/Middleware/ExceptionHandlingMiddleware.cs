using System.Text.Json;
using AmazonKiller.Shared.Exceptions;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Infrastructure.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (AppException ex)
        {
            context.Response.StatusCode = ex.StatusCode; // <<< Уважай статус код из AppException
            context.Response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(new
            {
                error = ex.Message
            });

            await context.Response.WriteAsync(result);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(new
            {
                error = "Internal server error",
                details = ex.Message // <-- можно убрать детали в продакшене
            });

            await context.Response.WriteAsync(result);
        }
    }
}