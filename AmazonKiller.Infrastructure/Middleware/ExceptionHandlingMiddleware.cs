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
            await WriteProblemDetailsAsync(context, ex.Message, StatusCodes.Status400BadRequest);
        }
        catch (JsonException ex) // ошибки при десериализации JSON
        {
            logger.LogWarning(ex, "Invalid JSON format");
            await WriteProblemDetailsAsync(context, "Invalid JSON format: " + ex.Message,
                StatusCodes.Status400BadRequest);
        }
        catch (FormatException ex) // например, неверный Guid
        {
            logger.LogWarning(ex, "Invalid input format");
            await WriteProblemDetailsAsync(context, "Invalid input format: " + ex.Message,
                StatusCodes.Status400BadRequest);
        }
        catch (InvalidOperationException ex) // частые ошибки приведения или ожидания значений
        {
            logger.LogWarning(ex, "Invalid operation");
            await WriteProblemDetailsAsync(context, ex.Message, StatusCodes.Status400BadRequest);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception occurred");
            await WriteProblemDetailsAsync(context, "An unexpected error occurred",
                StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task WriteProblemDetailsAsync(HttpContext context, string message, int statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var problem = new
        {
            title = statusCode switch
            {
                StatusCodes.Status400BadRequest => "Bad request",
                StatusCodes.Status401Unauthorized => "Unauthorized",
                StatusCodes.Status403Forbidden => "Forbidden",
                StatusCodes.Status404NotFound => "Not found",
                _ => "Internal server error"
            },
            detail = message,
            status = statusCode,
            instance = context.Request.Path
        };

        var json = JsonSerializer.Serialize(problem);
        await context.Response.WriteAsync(json);
    }
}