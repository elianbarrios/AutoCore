using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Module : AuditableEntity
{
    public long IdModule { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool Active { get; set; }

    public ICollection<Option> Options { get; set; } = [];
}