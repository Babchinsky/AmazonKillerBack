﻿namespace AmazonKiller.Application.DTOs.Auth;

public record AuthTokensDto
{
    public string AccessToken { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
}