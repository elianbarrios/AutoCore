using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class ModuleConfiguration : IEntityTypeConfiguration<Module>
{
    public void Configure(EntityTypeBuilder<Module> builder)
    {
        builder.ToTable("Module", table =>
        {
            table.HasCheckConstraint("CK_Module_Name_Length", "length(\"Name\") <= 100");
        });

        builder.HasKey(module => module.IdModule);

        builder.Property(module => module.IdModule)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(module => module.Name)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(module => module.Active)
            .IsRequired();

        builder.Property(module => module.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(module => module.UpdatedAt)
            .HasColumnType("timestamptz");
    }
}