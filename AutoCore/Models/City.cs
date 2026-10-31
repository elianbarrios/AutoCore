using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class City : AuditableEntity
{
    public long IdCity { get; set; }

    public string Name { get; set; } = string.Empty;

    public long IdState { get; set; }

    public State State { get; set; } = null!;

    public bool Active { get; set; }

    public ICollection<Customer> Customers { get; set; } = [];

    public ICollection<Employee> Employees { get; set; } = [];

    public ICollection<Supplier> Suppliers { get; set; } = [];
}