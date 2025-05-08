using Microsoft.EntityFrameworkCore;
using WalletAPI.Models;

namespace WalletAPI.Data
{
    public class WalletDbContext : DbContext
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.User)
                .WithOne(u => u.Wallet)
                .HasForeignKey<Wallet>(w => w.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
