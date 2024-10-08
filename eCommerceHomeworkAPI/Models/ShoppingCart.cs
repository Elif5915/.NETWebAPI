﻿namespace eCommerceHomeworkAPI.Models;

public sealed class ShoppingCart
{
    public ShoppingCart()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public decimal ProductPrice { get; set; }
}
