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
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AmazonKiller.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.TryAddSingleton<IPasswordService, PasswordService>();
        services.AddHttpClient<INovaPoshtaService, NovaPoshtaService>();
        
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

        return services;
    }
}