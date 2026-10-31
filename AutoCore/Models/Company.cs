using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Company : AuditableEntity
{
    public long IdCompany { get; set; }

    public string LegalName { get; set; } = string.Empty;

    public string? TradeName { get; set; }

    public string TaxId { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? LogoUrl { get; set; }
}