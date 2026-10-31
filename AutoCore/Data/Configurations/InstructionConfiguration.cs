using AutoCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCore.Data.Configurations;

public sealed class InstructionConfiguration : IEntityTypeConfiguration<Instruction>
{
    public void Configure(EntityTypeBuilder<Instruction> builder)
    {
        builder.ToTable("Instruction", table =>
        {
            table.HasCheckConstraint("CK_Instruction_Description_Length", "length(\"Description\") <= 150");
        });

        builder.HasKey(instruction => instruction.IdInstruction);

        builder.Property(instruction => instruction.IdInstruction)
            .ValueGeneratedOnAdd()
            .UseIdentityByDefaultColumn();

        builder.Property(instruction => instruction.Description)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(instruction => instruction.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(instruction => instruction.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.HasIndex(instruction => instruction.IdProcess);

        builder.HasOne(instruction => instruction.Process)
            .WithMany(process => process.Instructions)
            .HasForeignKey(instruction => instruction.IdProcess)
            .OnDelete(DeleteBehavior.Cascade);
    }
}