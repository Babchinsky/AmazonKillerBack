using System.Net;
using System.Text.Json;
using AmazonKiller.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AmazonKiller.Infrastructure.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (AppException ex) // кастомные исключения
        {
            logger.LogWarning(ex, "Handled application exception: {Message}", ex.Message);
            await WriteProblemDetailsAsync(context, ex.Message, (int)HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception occurred");
            await WriteProblemDetailsAsync(context, "An unexpected error occurred",
                (int)HttpStatusCode.InternalServerError);
        }
    }

    private static async Task WriteProblemDetailsAsync(HttpContext context, string message, int statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var problem = new
        {
            title = statusCode == 400 ? "Bad request" : "Internal server error",
            detail = message,
            status = statusCode,
            instance = context.Request.Path
        };

        var json = JsonSerializer.Serialize(problem);
        await context.Response.WriteAsync(json);
    }
}