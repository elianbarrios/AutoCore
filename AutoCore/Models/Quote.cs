using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Quote : AuditableEntity
{
    public long IdQuote { get; set; }

    public string Code { get; set; } = string.Empty;

    public DateTimeOffset Date { get; set; }

    public string? Comments { get; set; }

    public string Place { get; set; } = string.Empty;

    public decimal TotalServices { get; set; }

    public decimal TotalProducts { get; set; }

    public decimal Total { get; set; }

    public decimal Balance { get; set; }

    public string Status { get; set; } = string.Empty;

    public long IdUser { get; set; }

    public User User { get; set; } = null!;

    public long IdIntake { get; set; }

    public Intake Intake { get; set; } = null!;

    public long IdEmployee { get; set; }

    public Employee Employee { get; set; } = null!;

    public DateTimeOffset? VoidedAt { get; set; }

    public string? VoidReason { get; set; }

    public ICollection<Process> Processes { get; set; } = [];

    public ICollection<Payment> Payments { get; set; } = [];

    public ICollection<Sale> Sales { get; set; } = [];
}