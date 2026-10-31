using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class User : SoftDeletableEntity
{
    public long IdUser { get; set; }

    public string Name { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public long IdEmployee { get; set; }

    public Employee Employee { get; set; } = null!;

    public ICollection<Permission> Permissions { get; set; } = [];

    public ICollection<InventoryMovement> InventoryMovements { get; set; } = [];

    public ICollection<Quote> Quotes { get; set; } = [];

    public ICollection<Payment> Payments { get; set; } = [];

    public ICollection<Sale> Sales { get; set; } = [];
}