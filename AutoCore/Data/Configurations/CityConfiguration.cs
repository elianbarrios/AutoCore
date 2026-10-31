using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("City", table =>
        {
            table.HasCheckConstraint("CK_City_Name_Length", "length(\"Name\") <= 25");
        });

        builder.HasKey(city => city.IdCity);

        builder.Property(city => city.IdCity)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(city => city.Name)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(city => city.Active)
            .IsRequired();

        builder.Property(city => city.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(city => city.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(city => city.IdState);

        builder.HasOne(city => city.State)
            .WithMany(state => state.Cities)
            .HasForeignKey(city => city.IdState)
            .OnDelete(DeleteBehavior.Restrict);
    }
}