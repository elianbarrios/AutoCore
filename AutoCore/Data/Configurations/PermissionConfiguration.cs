using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permission");

        builder.HasKey(permission => permission.IdPermission);

        builder.Property(permission => permission.IdPermission)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(permission => permission.AssignedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(permission => permission.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(permission => permission.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(permission => new { permission.IdUser, permission.IdOption })
            .IsUnique();

        builder.HasIndex(permission => permission.IdOption);

        builder.HasOne(permission => permission.User)
            .WithMany(user => user.Permissions)
            .HasForeignKey(permission => permission.IdUser)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(permission => permission.Option)
            .WithMany(option => option.Permissions)
            .HasForeignKey(permission => permission.IdOption)
            .OnDelete(DeleteBehavior.Restrict);
    }
}