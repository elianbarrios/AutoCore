using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
{
    public void Configure(EntityTypeBuilder<SaleDetail> builder)
    {
        builder.ToTable("SaleDetail");

        builder.HasKey(saleDetail => saleDetail.IdSaleDetail);

        builder.Property(saleDetail => saleDetail.IdSaleDetail)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(saleDetail => saleDetail.Quantity)
            .IsRequired();

        builder.Property(saleDetail => saleDetail.Price)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(saleDetail => saleDetail.Total)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(saleDetail => saleDetail.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(saleDetail => saleDetail.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(saleDetail => saleDetail.IdSale);
        builder.HasIndex(saleDetail => saleDetail.IdProduct);

        builder.HasOne(saleDetail => saleDetail.Sale)
            .WithMany(sale => sale.Details)
            .HasForeignKey(saleDetail => saleDetail.IdSale)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(saleDetail => saleDetail.Product)
            .WithMany(product => product.SaleDetails)
            .HasForeignKey(saleDetail => saleDetail.IdProduct)
            .OnDelete(DeleteBehavior.Restrict);
    }
}