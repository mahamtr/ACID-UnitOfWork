using Ardalis.EFCore.Extensions;
using backend.Core.Entities;
using backend.Infrastructure.Configuration;
using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace backend.Infrastructure.Data
{
    public class BankDbContext : DbContext
    {

        public BankDbContext(DbContextOptions<BankDbContext> options  )
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<TransactionLog> TransactionLog { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            // modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
            // modelBuilder.Entity<User>().ToTable("Users");
            // modelBuilder.Entity<Accounts>().ToTable("Accounts").HasKey("AccountId");
            // modelBuilder.Entity<TransactionLog>().ToTable("TransactionLog").HasKey("Id");

        }



        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}    