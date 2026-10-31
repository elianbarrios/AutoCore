using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("State", table =>
        {
            table.HasCheckConstraint("CK_State_Name_Length", "length(\"Name\") <= 25");
        });

        builder.HasKey(state => state.IdState);

        builder.Property(state => state.IdState)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(state => state.Name)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(state => state.Active)
            .IsRequired();

        builder.Property(state => state.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(state => state.UpdatedAt)
            .HasColumnType("timestamptz");
    }
}