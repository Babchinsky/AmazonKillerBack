using System.Text;
using AmazonKiller.Application.DependencyInjection;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Infrastructure.Middleware;
using AmazonKiller.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:80");

// ----------  DI ----------
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services
    .AddPersistence(builder.Configuration) // БД
    .AddInfrastructure() // Репозитории/сервисы
    .AddApplication(); // MediatR / AutoMapper / валидаторы

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
        Description = @"Введите токен как: Bearer {токен}",
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
    var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
    var db = scope.ServiceProvider.GetRequiredService<AmazonDbContext>();

    if (!env.IsEnvironment("Testing"))
    {
        db.Database.Migrate(); // Только если не тесты!
    }
}

// --- Middleware ---
if (!app.Environment.IsEnvironment("Testing"))
{
    app.UseMiddleware<ExceptionHandlingMiddleware>();
}

// --- Swagger/Scalar UI ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

public partial class Program;