﻿namespace AmazonKiller.Application.DTOs.Orders;

public record OrderItemDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Code { get; init; } = string.Empty;
    public string? ImageUrl { get; init; } = string.Empty;
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}