using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class UnitType : AuditableEntity
{
    public long IdUnitType { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool Active { get; set; }

    public ICollection<Product> Products { get; set; } = [];
}