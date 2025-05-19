namespace AmazonKiller.WebApi.Extensions;

public static class StaticFilesConfiguration
{
    public static IApplicationBuilder ConfigureStaticFiles(this IApplicationBuilder app)
    {
        return app.UseStaticFiles(); // ← это критично!
    }
}