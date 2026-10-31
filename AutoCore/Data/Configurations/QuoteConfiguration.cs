using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class QuoteConfiguration : IEntityTypeConfiguration<Quote>
{
    public void Configure(EntityTypeBuilder<Quote> builder)
    {
        builder.ToTable("Quote", table =>
        {
            table.HasCheckConstraint("CK_Quote_Code_Length", "length(\"Code\") <= 20");
            table.HasCheckConstraint("CK_Quote_Comments_Length", "length(\"Comments\") <= 255");
            table.HasCheckConstraint("CK_Quote_Place_Length", "length(\"Place\") <= 200");
            table.HasCheckConstraint("CK_Quote_Status_Length", "length(\"Status\") <= 15");
            table.HasCheckConstraint("CK_Quote_VoidReason_Length", "length(\"VoidReason\") <= 255");
        });

        builder.HasKey(quote => quote.IdQuote);

        builder.Property(quote => quote.IdQuote)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(quote => quote.Code)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(quote => quote.Date)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(quote => quote.Comments)
            .HasColumnType("text");

        builder.Property(quote => quote.Place)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(quote => quote.TotalServices)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(quote => quote.TotalProducts)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(quote => quote.Total)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(quote => quote.Balance)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(quote => quote.Status)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(quote => quote.VoidedAt)
            .HasColumnType("timestamptz");

        builder.Property(quote => quote.VoidReason)
            .HasColumnType("text");

        builder.Property(quote => quote.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(quote => quote.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(quote => quote.IdUser);
        builder.HasIndex(quote => quote.IdIntake);
        builder.HasIndex(quote => quote.IdEmployee);

        builder.HasIndex(quote => quote.Code)
            .IsUnique();

        builder.HasOne(quote => quote.User)
            .WithMany(user => user.Quotes)
            .HasForeignKey(quote => quote.IdUser)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(quote => quote.Intake)
            .WithMany(intake => intake.Quotes)
            .HasForeignKey(quote => quote.IdIntake)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(quote => quote.Employee)
            .WithMany(employee => employee.PreparedQuotes)
            .HasForeignKey(quote => quote.IdEmployee)
            .OnDelete(DeleteBehavior.Restrict);
    }
}