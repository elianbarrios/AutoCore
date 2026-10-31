using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class VehicleBrandConfiguration : IEntityTypeConfiguration<VehicleBrand>
{
    public void Configure(EntityTypeBuilder<VehicleBrand> builder)
    {
        builder.ToTable("VehicleBrand", table =>
        {
            table.HasCheckConstraint("CK_VehicleBrand_Name_Length", "length(\"Name\") <= 50");
        });

        builder.HasKey(vehicleBrand => vehicleBrand.IdVehicleBrand);

        builder.Property(vehicleBrand => vehicleBrand.IdVehicleBrand)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(vehicleBrand => vehicleBrand.Name)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(vehicleBrand => vehicleBrand.Active)
            .IsRequired();

        builder.Property(vehicleBrand => vehicleBrand.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(vehicleBrand => vehicleBrand.UpdatedAt)
            .HasColumnType("timestamptz");
    }
}