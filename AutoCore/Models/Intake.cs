using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Intake : AuditableEntity
{
    public long IdIntake { get; set; }

    public string Code { get; set; } = string.Empty;

    public DateTimeOffset IntakeDate { get; set; }

    public DateTimeOffset? ExitDate { get; set; }

    public int? Mileage { get; set; }

    public string? Notes { get; set; }

    public string Status { get; set; } = string.Empty;

    public long IdVehicle { get; set; }

    public Vehicle Vehicle { get; set; } = null!;

    public long IdReceivingEmployee { get; set; }

    public Employee ReceivingEmployee { get; set; } = null!;

    public DateTimeOffset? VoidedAt { get; set; }

    public string? VoidReason { get; set; }

    public ICollection<Quote> Quotes { get; set; } = [];
}