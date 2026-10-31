using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class State : AuditableEntity
{
    public long IdState { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool Active { get; set; }

    public ICollection<City> Cities { get; set; } = [];
}