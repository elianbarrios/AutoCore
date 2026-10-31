using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class ProductBrand : AuditableEntity
{
    public long IdProductBrand { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool Active { get; set; }

    public ICollection<Product> Products { get; set; } = [];
}