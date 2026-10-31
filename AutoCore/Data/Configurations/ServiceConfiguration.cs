using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("Service", table =>
        {
            table.HasCheckConstraint("CK_Service_Name_Length", "length(\"Name\") <= 50");
            table.HasCheckConstraint("CK_Service_Description_Length", "length(\"Description\") <= 255");
        });

        builder.HasKey(service => service.IdService);

        builder.Property(service => service.IdService)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(service => service.Name)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(service => service.Description)
            .HasColumnType("text");

        builder.Property(service => service.Hours)
            .HasPrecision(9, 2)
            .IsRequired();

        builder.Property(service => service.Price)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(service => service.Active)
            .IsRequired();

        builder.Property(service => service.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(service => service.UpdatedAt)
            .HasColumnType("timestamptz");
    }
}