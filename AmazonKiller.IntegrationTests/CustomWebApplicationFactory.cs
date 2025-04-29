using AmazonKiller.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmazonKiller.IntegrationTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing"); // важно
        
        builder.ConfigureAppConfiguration((context, config) =>
        {
            var settings = new Dictionary<string, string>
            {
                ["Jwt:Key"] = "SuperTestKeyForJwt123!",
                ["Jwt:Issuer"] = "TestIssuer",
                ["Jwt:Audience"] = "TestAudience"
            };
            config.AddInMemoryCollection(settings!);
        });

        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<AmazonDbContext>));
            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<AmazonDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDb");
            });

            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AmazonDbContext>();
            db.Database.EnsureCreated();
        });
    }
}