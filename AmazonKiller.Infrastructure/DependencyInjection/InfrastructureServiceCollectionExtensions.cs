using AmazonKiller.Application.Interfaces;
using AmazonKiller.Infrastructure.Repositories;
using AmazonKiller.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AmazonKiller.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}