﻿namespace AmazonKiller.Application.Interfaces.Services;

public interface ICurrentUserService
{
    Guid UserId { get; }
}