using AmazonKiller.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AmazonKiller.Infrastructure.DependencyInjection;

public static class PersistenceServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddDbContext<AmazonDbContext>((sp, opt) =>
        {
            var env = sp.GetRequiredService<IWebHostEnvironment>();

            // Включаем SensitiveDataLogging только в Development среде
            // if (env.IsDevelopment())
            // {
            //     opt.EnableSensitiveDataLogging();
            // }

            // if (env.IsEnvironment("Testing"))
            //     opt.UseInMemoryDatabase("TestDb_Shared"); // обязательно фиксированное имя
            // else
            //     opt.UseSqlServer(cfg.GetConnectionString("DefaultConnection"));
            opt.UseSqlServer(cfg.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}