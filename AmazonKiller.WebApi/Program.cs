using System.Collections;
using AmazonKiller.Application.DependencyInjection;
using AmazonKiller.Application.Interfaces.Services.Recalculation;
using AmazonKiller.Application.Options;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Infrastructure.DependencyInjection;
using AmazonKiller.Infrastructure.Middleware;
using AmazonKiller.WebApi.Configuration;
using AmazonKiller.WebApi.Extensions;
using AmazonKiller.WebApi.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

foreach (var (key, value) in Environment.GetEnvironmentVariables().Cast<DictionaryEntry>())
{
    var envKey = key.ToString();
    if (envKey is not null && envKey.Contains('-'))
    {
        var convertedKey = envKey.Replace("-", "__");
        Environment.SetEnvironmentVariable(convertedKey, value?.ToString());
    }
}

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

    options.KnownNetworks.Clear(); // доверяем всем (можно ограничить, если надо)
    options.KnownProxies.Clear();
});

var port = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true" ? "80" : "5011";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// ----------  DI ----------
// builder.Services.AddControllers();
builder.Services.AddControllers(options => { options.Filters.Add<EnrichWithClientInfoFilter>(); });
builder.Services.AddHttpContextAccessor();

builder.Services
    .AddPersistence(builder.Configuration) // БД
    .AddInfrastructure() // Репозитории/сервисы
    .AddApplication(); // MediatR / AutoMapper / валидаторы

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<AdminOptions>(builder.Configuration.GetSection("Admin"));
builder.Services.Configure<NovaPoshtaOptions>(builder.Configuration.GetSection("NovaPoshta"));
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("Email"));
builder.Services.Configure<StripeSettingsOptions>(builder.Configuration.GetSection("Stripe"));
builder.Services.Configure<BlobStorageOptions>(builder.Configuration.GetSection("BlobStorage"));
builder.Services.Configure<GmailSettings>(builder.Configuration.GetSection("Gmail"));
builder.Services.Configure<VerificationOptions>(builder.Configuration.GetSection("Verification"));

Console.WriteLine($"🔐 Jwt:Key = {builder.Configuration["Jwt:Key"]}");

builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
builder.Services.AddAuthorization();

// ---------- Swagger / Scalar ----------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AmazonKiller API", Version = "v1" });

    // --- JWT авторизация в Swagger ---
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Введите токен как: Bearer {токен}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            []
        }
    });
});

builder.Services.Configure<ScalarOptions>(_ =>
{
    // Опционально: кастомизация Scalar UI
});

builder.Services.AddCors(p => p
    .AddDefaultPolicy(b =>
        b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// ---------- App ----------
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// --- Автоматическая миграция БД ---
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AmazonDbContext>();
    db.Database.Migrate();

    // рейтинги
    await scope.ServiceProvider.GetRequiredService<IProductRatingService>()
        .RecalculateAsync();

    // фильтры категорий
    await scope.ServiceProvider.GetRequiredService<ICategoryFilterService>()
        .RecalculateAsync(true);
}

app.UseForwardedHeaders();

// --- Middleware ---
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.ConfigureStaticFiles();

// --- Swagger/Scalar UI ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AmazonKiller API v1"));
    app.MapScalarApiReference(o => { o.OpenApiRoutePattern = "/swagger/{documentName}/swagger.json"; });
}
else
{
    app.UseHttpsRedirection();
}

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Logger.LogInformation("✅ AmazonKiller API started");
Console.WriteLine("🚀 App started OK");

app.Run();

namespace AmazonKiller.WebApi
{
    public partial class Program;
}