using backend.Core.Entities;
using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Configuration
{
    public class AccountConfiguration :  IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.Balance).IsRequired().HasColumnType("decimal(18,2)");
            

      
        }
    }
}