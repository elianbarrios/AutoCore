using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product", table =>
        {
            table.HasCheckConstraint("CK_Product_Code_Length", "length(\"Code\") <= 20");
            table.HasCheckConstraint("CK_Product_Name_Length", "length(\"Name\") <= 50");
            table.HasCheckConstraint("CK_Product_Description_Length", "length(\"Description\") <= 100");
            table.HasCheckConstraint("CK_Product_Status_Length", "length(\"Status\") <= 15");
            table.HasCheckConstraint("CK_Product_Stock_NonNegative", "\"Stock\" >= 0");
        });

        builder.HasKey(product => product.IdProduct);

        builder.Property(product => product.IdProduct)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(product => product.Code)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(product => product.Name)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(product => product.Description)
            .HasColumnType("text");

        builder.Property(product => product.CostPrice)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(product => product.SalePrice)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(product => product.Stock)
            .IsRequired();

        builder.Property(product => product.QuantityPerProduct)
            .IsRequired();

        builder.Property(product => product.Status)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(product => product.DeletedAt)
            .HasColumnType("timestamptz");

        builder.Property(product => product.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(product => product.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(product => product.IdSupplier);
        builder.HasIndex(product => product.IdProductBrand);
        builder.HasIndex(product => product.IdUnitType);

        builder.HasIndex(product => product.Code)
            .IsUnique()
            .HasFilter("\"DeletedAt\" IS NULL");

        builder.HasOne(product => product.Supplier)
            .WithMany(supplier => supplier.Products)
            .HasForeignKey(product => product.IdSupplier)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(product => product.ProductBrand)
            .WithMany(productBrand => productBrand.Products)
            .HasForeignKey(product => product.IdProductBrand)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(product => product.UnitType)
            .WithMany(unitType => unitType.Products)
            .HasForeignKey(product => product.IdUnitType)
            .OnDelete(DeleteBehavior.Restrict);
    }
}