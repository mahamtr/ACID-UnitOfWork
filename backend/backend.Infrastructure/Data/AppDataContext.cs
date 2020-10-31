using Ardalis.EFCore.Extensions;
using backend.Core.Entities;
using backend.Infrastructure.Configuration;
using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace backend.Infrastructure.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
        {
            
        }
        public AppDataContext(DbContextOptions<AppDataContext> options  )
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        // public DbSet<TransactionLog> TransactionLog { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionLogConfiguration());



        }



        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}    