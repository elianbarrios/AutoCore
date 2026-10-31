using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class VehicleModel : AuditableEntity
{
    public long IdVehicleModel { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public long IdVehicleBrand { get; set; }

    public VehicleBrand VehicleBrand { get; set; } = null!;

    public bool Active { get; set; }

    public ICollection<Vehicle> Vehicles { get; set; } = [];
}