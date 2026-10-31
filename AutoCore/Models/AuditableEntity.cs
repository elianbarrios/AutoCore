using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public abstract class AuditableEntity
{
    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}