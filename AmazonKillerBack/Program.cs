using AmazonKillerBack.Application.Features.Products.Create;
using AmazonKillerBack.Application.Features.Products.GetAll;
using AmazonKillerBack.Application.Interfaces;
using AmazonKillerBack.Application.Mappings;
using AmazonKillerBack.Infrastructure.Data;
using AmazonKillerBack.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Настройка хоста (для работы в Docker)
builder.WebHost.UseUrls("http://0.0.0.0:80");

// Контроллеры и инфраструктура
builder.Services.AddControllers();

// База данных
builder.Services.AddDbContext<AmazonDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Репозитории и маппинг
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllProductsQuery>());

// Валидация
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();

// OpenAPI / Scalar
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Настройка Scalar (тема, сервер)
builder.Services.Configure<ScalarOptions>(options =>
{
    options.Servers = new List<ScalarServer>
    {
        new("http://localhost:8080", "Local Dev Server")
    };
    options.Theme = ScalarTheme.Purple;
    options.DynamicBaseServerUrl = false;
});

var app = builder.Build();

// Авто-миграции
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AmazonDbContext>();
    db.Database.Migrate();
}

// Middleware
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
app.UseAuthorization();
app.MapControllers();
app.Run();