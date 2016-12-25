namespace Banking.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BankingDbContext : DbContext
    {
        public BankingDbContext()
            : base("name=BankingDbContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<UserTransaction> UserTransactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.AccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.AccountName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Balance)
                .HasPrecision(18, 6);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.UserTransactions)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<UserTransaction>()
                .Property(e => e.TransactionNo)
                .IsUnicode(false);

            modelBuilder.Entity<UserTransaction>()
                .Property(e => e.StartBalance)
                .HasPrecision(18, 6);

            modelBuilder.Entity<UserTransaction>()
                .Property(e => e.EndBalance)
                .HasPrecision(18, 6);

            modelBuilder.Entity<UserTransaction>()
                .Property(e => e.Amount)
                .HasPrecision(18, 6);
        }
    }
}
