using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder.Property(x => x.Purpose)
            .IsUnicode(false)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Amount).HasColumnType("decimal(18,2)");
    }
}