using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Customer : SoftDeletableEntity
{
    public long IdCustomer { get; set; }

    public string? NationalId { get; set; }

    public string TaxId { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = string.Empty;

    public string? SecondLastName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateOnly RegistrationDate { get; set; }

    public long IdCity { get; set; }

    public City City { get; set; } = null!;

    public ICollection<Vehicle> Vehicles { get; set; } = [];

    public ICollection<Sale> Sales { get; set; } = [];
}