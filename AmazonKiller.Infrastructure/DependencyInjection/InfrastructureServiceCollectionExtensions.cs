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
        services.AddScoped<IAccountRepository, AccountRepository>();
        // services.AddScoped<IEmailSender, ResendEmailSender>();
        services.AddScoped<IEmailSender, GmailEmailSender>();
        services.AddScoped<IEmailVerificationRepository, EmailVerificationRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAdminSecretValidator, AdminSecretValidator>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        return services;
    }
}