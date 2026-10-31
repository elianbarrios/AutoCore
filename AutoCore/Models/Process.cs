using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Process : AuditableEntity
{
    public long IdProcess { get; set; }

    public decimal Hours { get; set; }

    public decimal Price { get; set; }

    public decimal Amount { get; set; }

    public DateTimeOffset? StartedAt { get; set; }

    public DateTimeOffset? FinishedAt { get; set; }

    public string Status { get; set; } = string.Empty;

    public long IdQuote { get; set; }

    public Quote Quote { get; set; } = null!;

    public long IdService { get; set; }

    public Service Service { get; set; } = null!;

    public long IdEmployee { get; set; }

    public Employee Employee { get; set; } = null!;

    public DateTimeOffset? VoidedAt { get; set; }

    public string? VoidReason { get; set; }

    public ICollection<Instruction> Instructions { get; set; } = [];

    public ICollection<ProcessDetail> Details { get; set; } = [];
}