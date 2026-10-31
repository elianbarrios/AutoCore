using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class IntakeConfiguration : IEntityTypeConfiguration<Intake>
{
    public void Configure(EntityTypeBuilder<Intake> builder)
    {
        builder.ToTable("Intake", table =>
        {
            table.HasCheckConstraint("CK_Intake_Code_Length", "length(\"Code\") <= 20");
            table.HasCheckConstraint("CK_Intake_Notes_Length", "length(\"Notes\") <= 150");
            table.HasCheckConstraint("CK_Intake_Status_Length", "length(\"Status\") <= 15");
            table.HasCheckConstraint("CK_Intake_VoidReason_Length", "length(\"VoidReason\") <= 255");
        });

        builder.HasKey(intake => intake.IdIntake);

        builder.Property(intake => intake.IdIntake)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(intake => intake.Code)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(intake => intake.IntakeDate)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(intake => intake.ExitDate)
            .HasColumnType("timestamptz");

        builder.Property(intake => intake.Mileage);

        builder.Property(intake => intake.Notes)
            .HasColumnType("text");

        builder.Property(intake => intake.Status)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(intake => intake.VoidedAt)
            .HasColumnType("timestamptz");

        builder.Property(intake => intake.VoidReason)
            .HasColumnType("text");

        builder.Property(intake => intake.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(intake => intake.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(intake => intake.IdVehicle);
        builder.HasIndex(intake => intake.IdReceivingEmployee);

        builder.HasIndex(intake => intake.Code)
            .IsUnique();

        builder.HasOne(intake => intake.Vehicle)
            .WithMany(vehicle => vehicle.Intakes)
            .HasForeignKey(intake => intake.IdVehicle)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(intake => intake.ReceivingEmployee)
            .WithMany(employee => employee.ReceivedIntakes)
            .HasForeignKey(intake => intake.IdReceivingEmployee)
            .OnDelete(DeleteBehavior.Restrict);
    }
}