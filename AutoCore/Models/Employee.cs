using System;
using System.Collections.Generic;

namespace AutoCore.Models;

public class Employee : SoftDeletableEntity
{
    public long IdEmployee { get; set; }

    public string Code { get; set; } = string.Empty;

    public string NationalId { get; set; } = string.Empty;

    public string TaxId { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = string.Empty;

    public string? SecondLastName { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Gender { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public DateOnly HireDate { get; set; }

    public DateOnly? TerminationDate { get; set; }

    public string Position { get; set; } = string.Empty;

    public long IdCity { get; set; }

    public City City { get; set; } = null!;

    public User? User { get; set; }

    public ICollection<Intake> ReceivedIntakes { get; set; } = [];

    public ICollection<Quote> PreparedQuotes { get; set; } = [];

    public ICollection<Process> RepairedProcesses { get; set; } = [];
}