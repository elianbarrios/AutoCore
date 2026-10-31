using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public abstract class SoftDeletableEntity : AuditableEntity
{
    public DateTimeOffset? DeletedAt { get; set; }
}