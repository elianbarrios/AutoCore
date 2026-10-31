using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class OptionConfiguration : IEntityTypeConfiguration<Option>
{
    public void Configure(EntityTypeBuilder<Option> builder)
    {
        builder.ToTable("Option", table =>
        {
            table.HasCheckConstraint("CK_Option_Name_Length", "length(\"Name\") <= 100");
        });

        builder.HasKey(option => option.IdOption);

        builder.Property(option => option.IdOption)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(option => option.Name)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(option => option.Active)
            .IsRequired();

        builder.Property(option => option.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(option => option.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(option => option.IdModule);

        builder.HasOne(option => option.Module)
            .WithMany(module => module.Options)
            .HasForeignKey(option => option.IdModule)
            .OnDelete(DeleteBehavior.Restrict);
    }
}