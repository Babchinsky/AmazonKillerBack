using System.Text;
using AmazonKiller.Application.Features.Products.Commands.Create;
using AmazonKiller.Application.Features.Products.Queries.GetAll;
using AmazonKiller.Application.Interfaces;
using AmazonKiller.Application.Mappings;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Infrastructure.Repositories;
using AmazonKiller.Infrastructure.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// --- Host setup (для Docker)
builder.WebHost.UseUrls("http://0.0.0.0:80");

// --- Services
builder.Services.AddControllers();

// --- EF Core + DbContext
builder.Services.AddDbContext<AmazonDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --- JWT Auth
builder.Services.AddScoped<IAuthService, AuthService>();
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

// --- Repos, AutoMapper, MediatR
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllProductsQuery>());

// --- FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();

// --- OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// --- CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// --- Scalar UI Theme
builder.Services.Configure<ScalarOptions>(options =>
{
    options.Servers = new List<ScalarServer>
    {
        new("http://localhost:8080", "Local Dev Server")
    };
    options.Theme = ScalarTheme.Purple;
    options.DynamicBaseServerUrl = false;
});

// --- Build App
var app = builder.Build();

// --- Apply Migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AmazonDbContext>();
    db.Database.Migrate();
}

// --- Middleware
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
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