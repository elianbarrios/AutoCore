using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Option : AuditableEntity
{
    public long IdOption { get; set; }

    public string Name { get; set; } = string.Empty;

    public long IdModule { get; set; }

    public Module Module { get; set; } = null!;

    public bool Active { get; set; }

    public ICollection<Permission> Permissions { get; set; } = [];
}