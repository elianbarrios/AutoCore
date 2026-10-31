using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Vehicle : SoftDeletableEntity
{
    public long IdVehicle { get; set; }

    public string LicensePlate { get; set; } = string.Empty;

    public string? Vin { get; set; }

    public int? Year { get; set; }

    public string? Engine { get; set; }

    public string Color { get; set; } = string.Empty;

    public string? Description { get; set; }

    public long IdVehicleModel { get; set; }

    public VehicleModel VehicleModel { get; set; } = null!;

    public long IdCustomer { get; set; }

    public Customer Customer { get; set; } = null!;

    public ICollection<Intake> Intakes { get; set; } = [];
}