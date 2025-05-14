using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Admin.Users;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Interfaces.Services.Address;
using AmazonKiller.Infrastructure.Repositories.Account;
using AmazonKiller.Infrastructure.Repositories.Admin.Users;
using AmazonKiller.Infrastructure.Repositories.Auth;
using AmazonKiller.Infrastructure.Repositories.Products;
using AmazonKiller.Infrastructure.Repositories.Reviews;
using AmazonKiller.Infrastructure.Services;
using AmazonKiller.Infrastructure.Services.Address;
using AmazonKiller.Infrastructure.Services.Auth;
using AmazonKiller.Infrastructure.Services.Emails;
using AmazonKiller.Infrastructure.Services.FileStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AmazonKiller.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.TryAddSingleton<IPasswordService, PasswordService>();
        services.AddHttpClient<INovaPoshtaService, NovaPoshtaService>();
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.TryAddScoped<IAuthService, AuthService>();
        services.TryAddScoped<IProductRepository, ProductRepository>();
        services.TryAddScoped<ICurrentUserService, CurrentUserService>();
        services.TryAddScoped<IAccountRepository, AccountRepository>();
        services.TryAddScoped<IEmailSender, GmailEmailSender>();
        services.TryAddScoped<IEmailVerificationRepository, EmailVerificationRepository>();
        services.TryAddScoped<IUserRepository, UserRepository>();
        services.TryAddScoped<IAdminSecretValidator, AdminSecretValidator>();
        services.TryAddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.TryAddScoped<IWishlistRepository, WishlistRepository>();
        services.TryAddScoped<IOrderRepository, OrderRepository>();
        services.TryAddScoped<IVerificationEmailSender, VerificationEmailSender>();
        services.TryAddScoped<ICartRepository, CartRepository>();
        services.TryAddScoped<ICountryService, CountryService>();
        services.TryAddScoped<IAdminUserRepository, AdminUserRepository>();
        services.TryAddScoped<IReviewRepository, ReviewRepository>();
        services.TryAddScoped<ICategoryRepository, CategoryRepository>();
        services.TryAddScoped<IFileStorage, LocalFileStorage>();
        services.TryAddScoped<ICurrentRequestContext, CurrentRequestContext>();

        return services;
    }
}