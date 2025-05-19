// namespace подобран так, чтобы совпадать с другими WebApi-расширениями
namespace AmazonKiller.WebApi.Extensions;

using Microsoft.AspNetCore.StaticFiles;

public static class ProgramExtensions
{
    /// <summary>
    /// Включает раздачу /wwwroot с кеш-заголовком 1 год и поддержкой webp.
    /// Вызывать ВПЕРЕДИ UseRouting / UseAuthentication.
    /// </summary>
    public static WebApplication ConfigureStaticFiles(this WebApplication app)
    {
        app.UseStaticFiles(new StaticFileOptions
        {
            OnPrepareResponse = ctx =>
            {
                const int year = 31536000;            // сек
                ctx.Context.Response.Headers.CacheControl = $"public,max-age={year}";
            },
            ContentTypeProvider = new FileExtensionContentTypeProvider
            {
                Mappings = { [".webp"] = "image/webp" }
            }
        });

        return app;
    }
}