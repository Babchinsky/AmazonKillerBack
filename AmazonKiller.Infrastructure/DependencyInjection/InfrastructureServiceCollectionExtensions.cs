using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Admin.Users;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Collections;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Interfaces.Services.Address;
using AmazonKiller.Application.Interfaces.Services.Auth;
using AmazonKiller.Application.Interfaces.Services.Categories;
using AmazonKiller.Application.Interfaces.Services.Products;
using AmazonKiller.Infrastructure.Repositories.Account;
using AmazonKiller.Infrastructure.Repositories.Admin.Users;
using AmazonKiller.Infrastructure.Repositories.Auth;
using AmazonKiller.Infrastructure.Repositories.Categories;
using AmazonKiller.Infrastructure.Repositories.Collections;
using AmazonKiller.Infrastructure.Repositories.Products;
using AmazonKiller.Infrastructure.Repositories.Reviews;
using AmazonKiller.Infrastructure.Services;
using AmazonKiller.Infrastructure.Services.Address;
using AmazonKiller.Infrastructure.Services.Auth;
using AmazonKiller.Infrastructure.Services.Categories;
using AmazonKiller.Infrastructure.Services.Emails;
using AmazonKiller.Infrastructure.Services.FileStorage;
using AmazonKiller.Infrastructure.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AmazonKiller.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Services
        services.TryAddSingleton<IPasswordService, PasswordService>();
        services.TryAddScoped<IAuthService, AuthService>();
        services.TryAddScoped<IVerificationEmailSender, VerificationEmailSender>();
        services.TryAddScoped<IEmailSender, GmailEmailSender>();
        services.TryAddScoped<ICurrentRequestContext, CurrentRequestContext>();

        // External integrations
        services.AddHttpClient<INovaPoshtaService, NovaPoshtaService>();

        // Infrastructure
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.TryAddScoped<IFileStorage, LocalFileStorage>();
        services.TryAddScoped<IPropertyKeyUpdater, PropertyKeyUpdater>();

        // Repositories
        services.TryAddScoped<IProductRepository, ProductRepository>();
        services.TryAddScoped<ICategoryRepository, CategoryRepository>();
        services.TryAddScoped<IReviewRepository, ReviewRepository>();
        services.TryAddScoped<IUserRepository, UserRepository>();
        services.TryAddScoped<IAccountRepository, AccountRepository>();
        services.TryAddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.TryAddScoped<IEmailVerificationRepository, EmailVerificationRepository>();
        services.TryAddScoped<IAdminUserRepository, AdminUserRepository>();
        services.TryAddScoped<IOrderRepository, OrderRepository>();
        services.TryAddScoped<IWishlistRepository, WishlistRepository>();
        services.TryAddScoped<ICartRepository, CartRepository>();
        services.TryAddScoped<ICollectionRepository, CollectionRepository>();

        // Helpers
        services.TryAddScoped<ICurrentUserService, CurrentUserService>();
        services.TryAddScoped<IAdminSecretValidator, AdminSecretValidator>();
        services.TryAddScoped<ICountryService, CountryService>();
        services.TryAddScoped<ISequenceService, SequenceService>();
        services.TryAddScoped<ICategoryQueryService, CategoryQueryService>();
        services.TryAddScoped<ICategoryFilterBuilder, CategoryFilterBuilder>();

        return services;
    }
}