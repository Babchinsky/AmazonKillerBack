using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmazonKiller.Infrastructure.DependencyInjection;

public static class PersistenceServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddDbContext<AmazonDbContext>(opt
            =>
        {
            opt.UseSqlServer(cfg.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}