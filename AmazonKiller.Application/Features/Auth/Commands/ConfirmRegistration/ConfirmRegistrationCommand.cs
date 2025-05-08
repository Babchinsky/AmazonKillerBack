using System.Text.Json.Serialization;
using MediatR;
using AmazonKiller.Application.DTOs.Auth;

namespace AmazonKiller.Application.Features.Auth.Commands.ConfirmRegistration;

public record ConfirmRegistrationCommand(
    string Email,
    string Code,
    string DeviceId
) : IRequest<AuthTokensDto>
{
    [JsonIgnore] public string? IpAddress { get; set; }
    [JsonIgnore] public string? UserAgent { get; set; }
}