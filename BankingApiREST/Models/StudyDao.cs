namespace BankingApiREST.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudyDao : DbContext
    {
        public StudyDao()
            : base("name=StudyDao")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<IdentificationType> IdentificationTypes { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<MovementType> MovementTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.AccounCode)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Movements)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.SourceAccountId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bank>()
                .Property(e => e.BankName)
                .IsUnicode(false);

            modelBuilder.Entity<Bank>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Bank)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movement>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Movement>()
                .Property(e => e.GMF)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MovementType>()
                .Property(e => e.MovementName)
                .IsUnicode(false);

            modelBuilder.Entity<MovementType>()
                .HasMany(e => e.Movements)
                .WithRequired(e => e.MovementType)
                .WillCascadeOnDelete(false);
        }
    }
}
