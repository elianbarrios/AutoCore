using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee", table =>
        {
            table.HasCheckConstraint("CK_Employee_Code_Length", "length(\"Code\") <= 20");
            table.HasCheckConstraint("CK_Employee_NationalId_Length", "length(\"NationalId\") <= 20");
            table.HasCheckConstraint("CK_Employee_TaxId_Length", "length(\"TaxId\") <= 15");
            table.HasCheckConstraint("CK_Employee_FirstName_Length", "length(\"FirstName\") <= 35");
            table.HasCheckConstraint("CK_Employee_MiddleName_Length", "length(\"MiddleName\") <= 35");
            table.HasCheckConstraint("CK_Employee_LastName_Length", "length(\"LastName\") <= 35");
            table.HasCheckConstraint("CK_Employee_SecondLastName_Length", "length(\"SecondLastName\") <= 35");
            table.HasCheckConstraint("CK_Employee_Gender_Length", "length(\"Gender\") <= 15");
            table.HasCheckConstraint("CK_Employee_Phone_Length", "length(\"Phone\") <= 10");
            table.HasCheckConstraint("CK_Employee_Address_Length", "length(\"Address\") <= 150");
            table.HasCheckConstraint("CK_Employee_Position_Length", "length(\"Position\") <= 150");
        });

        builder.HasKey(employee => employee.IdEmployee);

        builder.Property(employee => employee.IdEmployee)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(employee => employee.Code)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(employee => employee.NationalId)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(employee => employee.TaxId)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(employee => employee.FirstName)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(employee => employee.MiddleName)
            .HasColumnType("text");

        builder.Property(employee => employee.LastName)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(employee => employee.SecondLastName)
            .HasColumnType("text");

        builder.Property(employee => employee.BirthDate)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(employee => employee.Gender)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(employee => employee.Phone)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(employee => employee.Address)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(employee => employee.HireDate)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(employee => employee.TerminationDate)
            .HasColumnType("date");

        builder.Property(employee => employee.Position)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(employee => employee.DeletedAt)
            .HasColumnType("timestamptz");

        builder.Property(employee => employee.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(employee => employee.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(employee => employee.IdCity);

        builder.HasIndex(employee => employee.Code)
            .IsUnique()
            .HasFilter("\"DeletedAt\" IS NULL");

        builder.HasOne(employee => employee.City)
            .WithMany(city => city.Employees)
            .HasForeignKey(employee => employee.IdCity)
            .OnDelete(DeleteBehavior.Restrict);
    }
}