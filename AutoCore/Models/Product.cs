using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Product : SoftDeletableEntity
{
    public long IdProduct { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal CostPrice { get; set; }

    public decimal SalePrice { get; set; }

    public int Stock { get; set; }

    public int QuantityPerProduct { get; set; }

    public string Status { get; set; } = string.Empty;

    public long IdSupplier { get; set; }

    public Supplier Supplier { get; set; } = null!;

    public long IdProductBrand { get; set; }

    public ProductBrand ProductBrand { get; set; } = null!;

    public long IdUnitType { get; set; }

    public UnitType UnitType { get; set; } = null!;

    public ICollection<InventoryMovement> InventoryMovements { get; set; } = [];

    public ICollection<ProcessDetail> ProcessDetails { get; set; } = [];

    public ICollection<SaleDetail> SaleDetails { get; set; } = [];
}