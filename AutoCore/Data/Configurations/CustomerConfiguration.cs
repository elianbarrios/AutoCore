using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer", table =>
        {
            table.HasCheckConstraint("CK_Customer_NationalId_Length", "length(\"NationalId\") <= 20");
            table.HasCheckConstraint("CK_Customer_TaxId_Length", "length(\"TaxId\") <= 15");
            table.HasCheckConstraint("CK_Customer_FirstName_Length", "length(\"FirstName\") <= 35");
            table.HasCheckConstraint("CK_Customer_MiddleName_Length", "length(\"MiddleName\") <= 35");
            table.HasCheckConstraint("CK_Customer_LastName_Length", "length(\"LastName\") <= 35");
            table.HasCheckConstraint("CK_Customer_SecondLastName_Length", "length(\"SecondLastName\") <= 35");
            table.HasCheckConstraint("CK_Customer_Phone_Length", "length(\"Phone\") <= 20");
            table.HasCheckConstraint("CK_Customer_Email_Length", "length(\"Email\") <= 50");
        });

        builder.HasKey(customer => customer.IdCustomer);

        builder.Property(customer => customer.IdCustomer)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(customer => customer.NationalId)
            .HasColumnType("text");

        builder.Property(customer => customer.TaxId)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(customer => customer.FirstName)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(customer => customer.MiddleName)
            .HasColumnType("text");

        builder.Property(customer => customer.LastName)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(customer => customer.SecondLastName)
            .HasColumnType("text");

        builder.Property(customer => customer.Phone)
            .HasColumnType("text");

        builder.Property(customer => customer.Email)
            .HasColumnType("text");

        builder.Property(customer => customer.RegistrationDate)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(customer => customer.DeletedAt)
            .HasColumnType("timestamptz");

        builder.Property(customer => customer.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(customer => customer.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(customer => customer.IdCity);

        builder.HasIndex(customer => customer.NationalId)
            .IsUnique()
            .HasFilter("\"NationalId\" IS NOT NULL AND \"DeletedAt\" IS NULL");

        builder.HasOne(customer => customer.City)
            .WithMany(city => city.Customers)
            .HasForeignKey(customer => customer.IdCity)
            .OnDelete(DeleteBehavior.Restrict);
    }
}