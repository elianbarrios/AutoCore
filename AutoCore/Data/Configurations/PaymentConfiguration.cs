using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payment", table =>
        {
            table.HasCheckConstraint("CK_Payment_Code_Length", "length(\"Code\") <= 20");
            table.HasCheckConstraint("CK_Payment_Concept_Length", "length(\"Concept\") <= 255");
            table.HasCheckConstraint("CK_Payment_Status_Length", "length(\"Status\") <= 15");
            table.HasCheckConstraint("CK_Payment_VoidReason_Length", "length(\"VoidReason\") <= 255");
            table.HasCheckConstraint(
                "CK_Payment_ExclusiveTarget",
                "num_nonnulls(\"IdQuote\", \"IdSale\") = 1");
        });

        builder.HasKey(payment => payment.IdPayment);

        builder.Property(payment => payment.IdPayment)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(payment => payment.Code)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(payment => payment.Date)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(payment => payment.Amount)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(payment => payment.Concept)
            .HasColumnType("text");

        builder.Property(payment => payment.Status)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(payment => payment.VoidedAt)
            .HasColumnType("timestamptz");

        builder.Property(payment => payment.VoidReason)
            .HasColumnType("text");

        builder.Property(payment => payment.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(payment => payment.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(payment => payment.IdUser);
        builder.HasIndex(payment => payment.IdQuote);
        builder.HasIndex(payment => payment.IdSale);

        builder.HasIndex(payment => payment.Code)
            .IsUnique();

        builder.HasOne(payment => payment.User)
            .WithMany(user => user.Payments)
            .HasForeignKey(payment => payment.IdUser)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(payment => payment.Quote)
            .WithMany(quote => quote.Payments)
            .HasForeignKey(payment => payment.IdQuote)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(payment => payment.Sale)
            .WithMany(sale => sale.Payments)
            .HasForeignKey(payment => payment.IdSale)
            .OnDelete(DeleteBehavior.Restrict);
    }
}