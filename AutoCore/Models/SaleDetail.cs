using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class SaleDetail : AuditableEntity
{
    public long IdSaleDetail { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal Total { get; set; }

    public long IdSale { get; set; }

    public Sale Sale { get; set; } = null!;

    public long IdProduct { get; set; }

    public Product Product { get; set; } = null!;

    public ICollection<InventoryMovement> InventoryMovements { get; set; } = [];
}