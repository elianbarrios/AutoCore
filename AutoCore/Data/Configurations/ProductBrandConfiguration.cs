using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        builder.ToTable("ProductBrand", table =>
        {
            table.HasCheckConstraint("CK_ProductBrand_Name_Length", "length(\"Name\") <= 100");
        });

        builder.HasKey(productBrand => productBrand.IdProductBrand);

        builder.Property(productBrand => productBrand.IdProductBrand)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(productBrand => productBrand.Name)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(productBrand => productBrand.Active)
            .IsRequired();

        builder.Property(productBrand => productBrand.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(productBrand => productBrand.UpdatedAt)
            .HasColumnType("timestamptz");
    }
}