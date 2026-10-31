using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class ProcessDetailConfiguration : IEntityTypeConfiguration<ProcessDetail>
{
    public void Configure(EntityTypeBuilder<ProcessDetail> builder)
    {
        builder.ToTable("ProcessDetail");

        builder.HasKey(processDetail => processDetail.IdProcessDetail);

        builder.Property(processDetail => processDetail.IdProcessDetail)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(processDetail => processDetail.Quantity)
            .IsRequired();

        builder.Property(processDetail => processDetail.Price)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(processDetail => processDetail.Total)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(processDetail => processDetail.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(processDetail => processDetail.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(processDetail => processDetail.IdProduct);
        builder.HasIndex(processDetail => processDetail.IdProcess);

        builder.HasOne(processDetail => processDetail.Product)
            .WithMany(product => product.ProcessDetails)
            .HasForeignKey(processDetail => processDetail.IdProduct)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(processDetail => processDetail.Process)
            .WithMany(process => process.Details)
            .HasForeignKey(processDetail => processDetail.IdProcess)
            .OnDelete(DeleteBehavior.Cascade);
    }
}