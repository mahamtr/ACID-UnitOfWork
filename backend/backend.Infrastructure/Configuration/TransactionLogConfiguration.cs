using backend.Core.Entities;
using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Configuration
{
    public class TransactionLogConfiguration :  IEntityTypeConfiguration<TransactionLog>
    {
        public void Configure(EntityTypeBuilder<TransactionLog> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.TransactionType).HasMaxLength(255).IsRequired();
            builder.Property(p => p.SourceAccountId).HasMaxLength(255);
            builder.Property(p => p.DestinationAccountId).HasMaxLength(255);
            
            
            
            builder.HasOne(pr => pr.User)
                .WithMany(pr => pr.TransacionLogs)
                .HasForeignKey(tc => tc.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            
        }
    }
}