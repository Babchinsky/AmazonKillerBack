﻿namespace AmazonKiller.Application.DTOs.Account.ProductCart;

public class ProductInCartDto
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Total => Price * Quantity;
}