using AmazonKiller.Application.Interfaces;
using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Infrastructure.Repositories;
using AmazonKiller.Infrastructure.Repositories.Account;
using AmazonKiller.Infrastructure.Repositories.Auth;
using AmazonKiller.Infrastructure.Repositories.Products;
using AmazonKiller.Infrastructure.Services;
using AmazonKiller.Infrastructure.Services.Auth;
using AmazonKiller.Infrastructure.Services.Common;
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
        services.AddScoped<IWishlistRepository, WishlistRepository>();

        return services;
    }
}