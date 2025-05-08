using System.Text.Json.Serialization;
using AmazonKiller.Application.DTOs.Auth;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Login;

public record LoginUserCommand(
    string Email,
    string Password,
    string DeviceId
) : IRequest<AuthTokensDto>
{
    [JsonIgnore] public string? IpAddress { get; set; }

    [JsonIgnore] public string? UserAgent { get; set; }
}