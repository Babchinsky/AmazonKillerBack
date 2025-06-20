﻿namespace AmazonKiller.Application.Interfaces.Services.Auth;

public interface IPasswordService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string? hash);
}