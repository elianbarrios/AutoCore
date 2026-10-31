using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class InventoryMovement : AuditableEntity
{
    public long IdMovement { get; set; }

    public DateTimeOffset Date { get; set; }

    public string Type { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal UnitCost { get; set; }

    public decimal Total { get; set; }

    public string? Reference { get; set; }

    public long IdProduct { get; set; }

    public Product Product { get; set; } = null!;

    public long IdUser { get; set; }

    public User User { get; set; } = null!;

    public long? IdProcessDetail { get; set; }

    public ProcessDetail? ProcessDetail { get; set; }

    public long? IdSaleDetail { get; set; }

    public SaleDetail? SaleDetail { get; set; }
}