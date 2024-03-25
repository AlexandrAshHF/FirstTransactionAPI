using Microsoft.EntityFrameworkCore;
using Transactions.Core.Entities;
using Transactions.Persistance.Configurations;

namespace Transactions.Persistance
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CardEntity> Cards { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<CurrencyAccount> CurrencyAccounts { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyAccountConfiguration());
        }
    }
}
