using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class UnitTypeConfiguration : IEntityTypeConfiguration<UnitType>
{
    public void Configure(EntityTypeBuilder<UnitType> builder)
    {
        builder.ToTable("UnitType", table =>
        {
            table.HasCheckConstraint("CK_UnitType_Name_Length", "length(\"Name\") <= 200");
            table.HasCheckConstraint("CK_UnitType_Description_Length", "length(\"Description\") <= 150");
        });

        builder.HasKey(unitType => unitType.IdUnitType);

        builder.Property(unitType => unitType.IdUnitType)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(unitType => unitType.Name)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(unitType => unitType.Description)
            .HasColumnType("text");

        builder.Property(unitType => unitType.Active)
            .IsRequired();

        builder.Property(unitType => unitType.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(unitType => unitType.UpdatedAt)
            .HasColumnType("timestamptz");
    }
}