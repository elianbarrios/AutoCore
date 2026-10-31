using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Sale : AuditableEntity
{
    public long IdSale { get; set; }

    public string Code { get; set; } = string.Empty;

    public DateTimeOffset Date { get; set; }

    public int ProductCount { get; set; }

    public decimal Total { get; set; }

    public string Status { get; set; } = string.Empty;

    public long IdCustomer { get; set; }

    public Customer Customer { get; set; } = null!;

    public long IdUser { get; set; }

    public User User { get; set; } = null!;

    public long? IdQuote { get; set; }

    public Quote? Quote { get; set; }

    public DateTimeOffset? VoidedAt { get; set; }

    public ICollection<SaleDetail> Details { get; set; } = [];

    public ICollection<Payment> Payments { get; set; } = [];
}