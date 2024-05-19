using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client", "dbo");
        builder.Property(x => x.FirstName)
            .IsUnicode(false)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.LastName)
            .IsUnicode(false)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Email)
            .IsUnicode(false)
            .HasMaxLength(100);
        
        builder
            .HasMany(c => c.Accounts)
            .WithOne(a => a.Client)
            .HasForeignKey(a => a.ClientId);
    }
}