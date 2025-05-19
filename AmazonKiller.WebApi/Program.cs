using System.Text;
using AmazonKiller.Application.DependencyInjection;
using AmazonKiller.Application.Options;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Infrastructure.DependencyInjection;
using AmazonKiller.Infrastructure.Middleware;
using AmazonKiller.WebApi.Extensions;
using AmazonKiller.WebApi.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

    options.KnownNetworks.Clear(); // доверяем всем (можно ограничить, если надо)
    options.KnownProxies.Clear();
});

builder.WebHost.UseUrls("http://0.0.0.0:80");

// ----------  DI ----------
// builder.Services.AddControllers();
builder.Services.AddControllers(options => { options.Filters.Add<EnrichWithClientInfoFilter>(); });
builder.Services.AddHttpContextAccessor();

builder.Services
    .AddPersistence(builder.Configuration) // БД
    .AddInfrastructure() // Репозитории/сервисы
    .AddApplication(); // MediatR / AutoMapper / валидаторы

builder.Services.Configure<NovaPoshtaOptions>(builder.Configuration.GetSection("NovaPoshta"));
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("Email"));

// ---------- JWT ----------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"]
        };
    });

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
var app = builder.Build();

// --- Автоматическая миграция БД ---
using (var scope = app.Services.CreateScope())
{
    // var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
    var db = scope.ServiceProvider.GetRequiredService<AmazonDbContext>();

    // if (!env.IsEnvironment("Testing")) 
    db.Database.Migrate(); // Только если не тесты!
}

app.UseForwardedHeaders();

// --- Middleware ---
app.UseMiddleware<ExceptionHandlingMiddleware>();
StaticFilesConfiguration.ConfigureStaticFiles(app);

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

app.Run();

namespace AmazonKiller.WebApi
{
    public partial class Program;
}