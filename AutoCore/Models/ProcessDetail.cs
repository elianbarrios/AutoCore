using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class ProcessDetail : AuditableEntity
{
    public long IdProcessDetail { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal Total { get; set; }

    public long IdProduct { get; set; }

    public Product Product { get; set; } = null!;

    public long IdProcess { get; set; }

    public Process Process { get; set; } = null!;

    public ICollection<InventoryMovement> InventoryMovements { get; set; } = [];
}