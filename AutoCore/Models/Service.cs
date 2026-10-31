using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Service : AuditableEntity
{
    public long IdService { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal Hours { get; set; }

    public decimal Price { get; set; }

    public bool Active { get; set; }

    public ICollection<Process> Processes { get; set; } = [];
}