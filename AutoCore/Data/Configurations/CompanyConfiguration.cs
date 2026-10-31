using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Company", table =>
        {
            table.HasCheckConstraint("CK_Company_LegalName_Length", "length(\"LegalName\") <= 150");
            table.HasCheckConstraint("CK_Company_TradeName_Length", "length(\"TradeName\") <= 150");
            table.HasCheckConstraint("CK_Company_TaxId_Length", "length(\"TaxId\") <= 15");
            table.HasCheckConstraint("CK_Company_Address_Length", "length(\"Address\") <= 255");
            table.HasCheckConstraint("CK_Company_Phone_Length", "length(\"Phone\") <= 50");
            table.HasCheckConstraint("CK_Company_Email_Length", "length(\"Email\") <= 100");
            table.HasCheckConstraint("CK_Company_LogoUrl_Length", "length(\"LogoUrl\") <= 255");
        });

        builder.HasKey(company => company.IdCompany);

        builder.Property(company => company.IdCompany)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(company => company.LegalName)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(company => company.TradeName)
            .HasColumnType("text");

        builder.Property(company => company.TaxId)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(company => company.Address)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(company => company.Phone)
            .HasColumnType("text");

        builder.Property(company => company.Email)
            .HasColumnType("text");

        builder.Property(company => company.LogoUrl)
            .HasColumnType("text");

        builder.Property(company => company.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(company => company.UpdatedAt)
            .HasColumnType("timestamptz");
    }
}