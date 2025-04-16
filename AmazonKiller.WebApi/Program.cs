using System.Text;
using AmazonKiller.Application.Features.Products.Commands.Create;
using AmazonKiller.Application.Features.Products.Queries.GetAll;
using AmazonKiller.Application.Interfaces;
using AmazonKiller.Application.Mappings;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Infrastructure.Features.Auth;
using AmazonKiller.Infrastructure.Middleware;
using AmazonKiller.Infrastructure.Repositories;
using AmazonKiller.Infrastructure.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// === Хост для Docker ===
builder.WebHost.UseUrls("http://0.0.0.0:80");

// === Сервисы ===
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// === БД ===
builder.Services.AddDbContext<AmazonDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// === JWT Аутентификация ===
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization();

// === Репозитории, Сервисы, Маппинг ===
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<GetAllProductsQuery>();
    cfg.RegisterServicesFromAssemblyContaining<RefreshTokenHandler>();
});


// === Валидация ===
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();

// === OpenAPI / Swagger / Scalar ===
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AmazonKiller API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT в формате Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
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
            Array.Empty<string>()
        }
    });
});

builder.Services.Configure<ScalarOptions>(options =>
{
    options.Servers = new List<ScalarServer>
    {
        new("http://localhost:8080", "Local Dev Server")
    };
    options.Theme = ScalarTheme.Purple;
    options.DynamicBaseServerUrl = false;
});

// === CORS ===
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// === Приложение ===
var app = builder.Build();

// --- Миграции
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AmazonDbContext>();
    db.Database.Migrate();
}

// === Middleware ===
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // обязательно, иначе swagger.json не сгенерится
    app.UseSwaggerUI(); // не обязательно для Scalar, но удобно

    app.MapScalarApiReference(options => { options.OpenApiRoutePattern = "/swagger/{documentName}/swagger.json"; });
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