using backend.Core.Entities;
using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Configuration
{
    public class UserConfiguration :  IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UserName).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(255).IsRequired();

            builder.HasOne(p => p.Account)
                .WithOne(c => c.User)
                .HasForeignKey<Account>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}