using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Instruction : AuditableEntity
{
    public long IdInstruction { get; set; }

    public string Description { get; set; } = string.Empty;

    public long IdProcess { get; set; }

    public Process Process { get; set; } = null!;
}