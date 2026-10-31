using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Supplier : SoftDeletableEntity
{
    public long IdSupplier { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public long IdCity { get; set; }

    public City City { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = [];
}