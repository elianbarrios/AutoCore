using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class ProcessConfiguration : IEntityTypeConfiguration<Process>
{
    public void Configure(EntityTypeBuilder<Process> builder)
    {
        builder.ToTable("Process", table =>
        {
            table.HasCheckConstraint("CK_Process_Status_Length", "length(\"Status\") <= 15");
            table.HasCheckConstraint("CK_Process_VoidReason_Length", "length(\"VoidReason\") <= 255");
        });

        builder.HasKey(process => process.IdProcess);

        builder.Property(process => process.IdProcess)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(process => process.Hours)
            .HasPrecision(9, 2)
            .IsRequired();

        builder.Property(process => process.Price)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(process => process.Amount)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(process => process.StartedAt)
            .HasColumnType("timestamptz");

        builder.Property(process => process.FinishedAt)
            .HasColumnType("timestamptz");

        builder.Property(process => process.Status)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(process => process.VoidedAt)
            .HasColumnType("timestamptz");

        builder.Property(process => process.VoidReason)
            .HasColumnType("text");

        builder.Property(process => process.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(process => process.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(process => process.IdQuote);
        builder.HasIndex(process => process.IdService);
        builder.HasIndex(process => process.IdEmployee);

        builder.HasOne(process => process.Quote)
            .WithMany(quote => quote.Processes)
            .HasForeignKey(process => process.IdQuote)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(process => process.Service)
            .WithMany(service => service.Processes)
            .HasForeignKey(process => process.IdService)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(process => process.Employee)
            .WithMany(employee => employee.RepairedProcesses)
            .HasForeignKey(process => process.IdEmployee)
            .OnDelete(DeleteBehavior.Restrict);
    }
}