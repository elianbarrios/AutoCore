using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class VehicleBrand : AuditableEntity
{
    public long IdVehicleBrand { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool Active { get; set; }

    public ICollection<VehicleModel> VehicleModels { get; set; } = [];
}