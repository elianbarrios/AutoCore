using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicle", table =>
        {
            table.HasCheckConstraint("CK_Vehicle_LicensePlate_Length", "length(\"LicensePlate\") <= 50");
            table.HasCheckConstraint("CK_Vehicle_Vin_Length", "length(\"Vin\") <= 17");
            table.HasCheckConstraint("CK_Vehicle_Engine_Length", "length(\"Engine\") <= 50");
            table.HasCheckConstraint("CK_Vehicle_Color_Length", "length(\"Color\") <= 50");
            table.HasCheckConstraint("CK_Vehicle_Description_Length", "length(\"Description\") <= 255");
        });

        builder.HasKey(vehicle => vehicle.IdVehicle);

        builder.Property(vehicle => vehicle.IdVehicle)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(vehicle => vehicle.LicensePlate)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(vehicle => vehicle.Vin)
            .HasColumnType("text");

        builder.Property(vehicle => vehicle.Year);

        builder.Property(vehicle => vehicle.Engine)
            .HasColumnType("text");

        builder.Property(vehicle => vehicle.Color)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(vehicle => vehicle.Description)
            .HasColumnType("text");

        builder.Property(vehicle => vehicle.DeletedAt)
            .HasColumnType("timestamptz");

        builder.Property(vehicle => vehicle.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(vehicle => vehicle.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(vehicle => vehicle.IdVehicleModel);
        builder.HasIndex(vehicle => vehicle.IdCustomer);

        builder.HasIndex(vehicle => vehicle.LicensePlate)
            .IsUnique()
            .HasFilter("\"DeletedAt\" IS NULL");

        builder.HasIndex(vehicle => vehicle.Vin)
            .IsUnique()
            .HasFilter("\"Vin\" IS NOT NULL AND \"DeletedAt\" IS NULL");

        builder.HasOne(vehicle => vehicle.VehicleModel)
            .WithMany(vehicleModel => vehicleModel.Vehicles)
            .HasForeignKey(vehicle => vehicle.IdVehicleModel)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(vehicle => vehicle.Customer)
            .WithMany(customer => customer.Vehicles)
            .HasForeignKey(vehicle => vehicle.IdCustomer)
            .OnDelete(DeleteBehavior.Restrict);
    }
}