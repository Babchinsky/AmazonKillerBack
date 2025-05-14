using System.Text.Json.Serialization;
using AmazonKiller.Application.DTOs.Auth;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Refresh;

public record RefreshTokenCommand(string RefreshToken, string DeviceId) : IRequest<AuthTokensDto>;