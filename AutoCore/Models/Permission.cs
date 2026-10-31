using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Permission : AuditableEntity
{
    public long IdPermission { get; set; }

    public DateTimeOffset AssignedAt { get; set; }

    public long IdUser { get; set; }

    public User User { get; set; } = null!;

    public long IdOption { get; set; }

    public Option Option { get; set; } = null!;
}