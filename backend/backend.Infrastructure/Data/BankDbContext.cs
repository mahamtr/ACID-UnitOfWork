using Ardalis.EFCore.Extensions;
using backend.Core.Entities;
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

        public DbSet<Users> Users { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<TransactionLog> TransactionLog { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Accounts>().ToTable("Accounts").HasKey("AccountId");
            modelBuilder.Entity<TransactionLog>().ToTable("TransactionLog").HasKey("Id");

        }



        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}    