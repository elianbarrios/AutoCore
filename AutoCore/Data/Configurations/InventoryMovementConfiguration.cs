using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class InventoryMovementConfiguration : IEntityTypeConfiguration<InventoryMovement>
{
    public void Configure(EntityTypeBuilder<InventoryMovement> builder)
    {
        builder.ToTable("InventoryMovement", table =>
        {
            table.HasCheckConstraint("CK_InventoryMovement_Type_Length", "length(\"Type\") <= 15");
            table.HasCheckConstraint("CK_InventoryMovement_Reference_Length", "length(\"Reference\") <= 50");
            table.HasCheckConstraint(
                "CK_InventoryMovement_ExclusiveDetail",
                "num_nonnulls(\"IdProcessDetail\", \"IdSaleDetail\") <= 1");
        });

        builder.HasKey(inventoryMovement => inventoryMovement.IdMovement);

        builder.Property(inventoryMovement => inventoryMovement.IdMovement)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(inventoryMovement => inventoryMovement.Date)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(inventoryMovement => inventoryMovement.Type)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(inventoryMovement => inventoryMovement.Quantity)
            .IsRequired();

        builder.Property(inventoryMovement => inventoryMovement.UnitCost)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(inventoryMovement => inventoryMovement.Total)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(inventoryMovement => inventoryMovement.Reference)
            .HasColumnType("text");

        builder.Property(inventoryMovement => inventoryMovement.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(inventoryMovement => inventoryMovement.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(inventoryMovement => inventoryMovement.IdProduct);
        builder.HasIndex(inventoryMovement => inventoryMovement.IdUser);
        builder.HasIndex(inventoryMovement => inventoryMovement.IdProcessDetail);
        builder.HasIndex(inventoryMovement => inventoryMovement.IdSaleDetail);

        builder.HasOne(inventoryMovement => inventoryMovement.Product)
            .WithMany(product => product.InventoryMovements)
            .HasForeignKey(inventoryMovement => inventoryMovement.IdProduct)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(inventoryMovement => inventoryMovement.User)
            .WithMany(user => user.InventoryMovements)
            .HasForeignKey(inventoryMovement => inventoryMovement.IdUser)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(inventoryMovement => inventoryMovement.ProcessDetail)
            .WithMany(processDetail => processDetail.InventoryMovements)
            .HasForeignKey(inventoryMovement => inventoryMovement.IdProcessDetail)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(inventoryMovement => inventoryMovement.SaleDetail)
            .WithMany(saleDetail => saleDetail.InventoryMovements)
            .HasForeignKey(inventoryMovement => inventoryMovement.IdSaleDetail)
            .OnDelete(DeleteBehavior.Restrict);
    }
}