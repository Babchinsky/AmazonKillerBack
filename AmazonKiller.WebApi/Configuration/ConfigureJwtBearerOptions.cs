using AmazonKiller.Application.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AmazonKiller.WebApi.Configuration;

public class ConfigureJwtBearerOptions(IOptions<JwtOptions> jwtOptions) : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwt = jwtOptions.Value;

    public void Configure(string? name, JwtBearerOptions options)
    {
        if (name != JwtBearerDefaults.AuthenticationScheme)
            return;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key)),
            ValidIssuer = _jwt.Issuer,
            ValidAudience = _jwt.Audience
        };
    }

    public void Configure(JwtBearerOptions options) => Configure(JwtBearerDefaults.AuthenticationScheme, options);
}