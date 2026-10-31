using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.ToTable("VehicleModel", table =>
        {
            table.HasCheckConstraint("CK_VehicleModel_Name_Length", "length(\"Name\") <= 50");
            table.HasCheckConstraint("CK_VehicleModel_Description_Length", "length(\"Description\") <= 100");
        });

        builder.HasKey(vehicleModel => vehicleModel.IdVehicleModel);

        builder.Property(vehicleModel => vehicleModel.IdVehicleModel)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(vehicleModel => vehicleModel.Name)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(vehicleModel => vehicleModel.Description)
            .HasColumnType("text");

        builder.Property(vehicleModel => vehicleModel.Active)
            .IsRequired();

        builder.Property(vehicleModel => vehicleModel.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(vehicleModel => vehicleModel.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(vehicleModel => vehicleModel.IdVehicleBrand);

        builder.HasOne(vehicleModel => vehicleModel.VehicleBrand)
            .WithMany(vehicleBrand => vehicleBrand.VehicleModels)
            .HasForeignKey(vehicleModel => vehicleModel.IdVehicleBrand)
            .OnDelete(DeleteBehavior.Restrict);
    }
}