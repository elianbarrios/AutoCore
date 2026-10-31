using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Payment : AuditableEntity
{
    public long IdPayment { get; set; }

    public string Code { get; set; } = string.Empty;

    public DateTimeOffset Date { get; set; }

    public decimal Amount { get; set; }

    public string? Concept { get; set; }

    public string Status { get; set; } = string.Empty;

    public long IdUser { get; set; }

    public User User { get; set; } = null!;

    public long? IdQuote { get; set; }

    public Quote? Quote { get; set; }

    public long? IdSale { get; set; }

    public Sale? Sale { get; set; }

    public DateTimeOffset? VoidedAt { get; set; }

    public string? VoidReason { get; set; }
}