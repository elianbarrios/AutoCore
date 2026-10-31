using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Supplier", table =>
        {
            table.HasCheckConstraint("CK_Supplier_Name_Length", "length(\"Name\") <= 150");
            table.HasCheckConstraint("CK_Supplier_Phone_Length", "length(\"Phone\") <= 15");
            table.HasCheckConstraint("CK_Supplier_Address_Length", "length(\"Address\") <= 150");
        });

        builder.HasKey(supplier => supplier.IdSupplier);

        builder.Property(supplier => supplier.IdSupplier)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(supplier => supplier.Name)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(supplier => supplier.Phone)
            .HasColumnType("text");

        builder.Property(supplier => supplier.Address)
            .HasColumnType("text");

        builder.Property(supplier => supplier.DeletedAt)
            .HasColumnType("timestamptz");

        builder.Property(supplier => supplier.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(supplier => supplier.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(supplier => supplier.IdCity);

        builder.HasOne(supplier => supplier.City)
            .WithMany(city => city.Suppliers)
            .HasForeignKey(supplier => supplier.IdCity)
            .OnDelete(DeleteBehavior.Restrict);
    }
}