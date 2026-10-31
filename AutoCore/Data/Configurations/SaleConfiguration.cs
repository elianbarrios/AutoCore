using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sale", table =>
        {
            table.HasCheckConstraint("CK_Sale_Code_Length", "length(\"Code\") <= 20");
            table.HasCheckConstraint("CK_Sale_Status_Length", "length(\"Status\") <= 15");
        });

        builder.HasKey(sale => sale.IdSale);

        builder.Property(sale => sale.IdSale)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(sale => sale.Code)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(sale => sale.Date)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(sale => sale.ProductCount)
            .IsRequired();

        builder.Property(sale => sale.Total)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(sale => sale.Status)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(sale => sale.VoidedAt)
            .HasColumnType("timestamptz");

        builder.Property(sale => sale.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(sale => sale.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(sale => sale.IdCustomer);
        builder.HasIndex(sale => sale.IdUser);
        builder.HasIndex(sale => sale.IdQuote);

        builder.HasIndex(sale => sale.Code)
            .IsUnique();

        builder.HasOne(sale => sale.Customer)
            .WithMany(customer => customer.Sales)
            .HasForeignKey(sale => sale.IdCustomer)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sale => sale.User)
            .WithMany(user => user.Sales)
            .HasForeignKey(sale => sale.IdUser)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sale => sale.Quote)
            .WithMany(quote => quote.Sales)
            .HasForeignKey(sale => sale.IdQuote)
            .OnDelete(DeleteBehavior.Restrict);
    }
}