﻿namespace AmazonKiller.Application.Interfaces.Auth;

public interface IEmailSender
{
    Task SendEmailAsync(string to, string subject, string htmlBody);
}