using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User", table =>
        {
            table.HasCheckConstraint("CK_User_Name_Length", "length(\"Name\") <= 50");
            table.HasCheckConstraint("CK_User_PasswordHash_Length", "length(\"PasswordHash\") <= 255");
        });

        builder.HasKey(user => user.IdUser);

        builder.Property(user => user.IdUser)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(user => user.Name)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(user => user.PasswordHash)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(user => user.DeletedAt)
            .HasColumnType("timestamptz");

        builder.Property(user => user.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(user => user.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(user => user.Name)
            .IsUnique()
            .HasFilter("\"DeletedAt\" IS NULL");

        builder.HasIndex(user => user.IdEmployee)
            .IsUnique();

        builder.HasOne(user => user.Employee)
            .WithOne(employee => employee.User)
            .HasForeignKey<User>(user => user.IdEmployee)
            .OnDelete(DeleteBehavior.Restrict);
    }
}