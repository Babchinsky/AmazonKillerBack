using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Common.Address;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Admin.Users;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Infrastructure.Repositories.Account;
using AmazonKiller.Infrastructure.Repositories.Admin.Users;
using AmazonKiller.Infrastructure.Repositories.Auth;
using AmazonKiller.Infrastructure.Repositories.Products;
using AmazonKiller.Infrastructure.Repositories.Reviews;
using AmazonKiller.Infrastructure.Services.Auth;
using AmazonKiller.Infrastructure.Services.Common;
using AmazonKiller.Infrastructure.Services.Common.Address;
using AmazonKiller.Infrastructure.Services.Common.Emails;
using AmazonKiller.Infrastructure.Services.Common.FileStorage;
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
        services.AddScoped<IEmailSender, GmailEmailSender>();
        services.AddScoped<IEmailVerificationRepository, EmailVerificationRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAdminSecretValidator, AdminSecretValidator>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IWishlistRepository, WishlistRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IVerificationEmailSender, VerificationEmailSender>();
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IAdminUserRepository, AdminUserRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IFileStorage, LocalFileStorage>();

        services.AddHttpClient<INovaPoshtaService, NovaPoshtaService>();

        return services;
    }
}