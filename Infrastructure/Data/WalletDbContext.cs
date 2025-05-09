using Microsoft.EntityFrameworkCore;
using WalletAPI.Domain.Models;

namespace WalletAPI.Infrastructure.Data;

public class WalletDbContext : DbContext
{
    public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Wallet)
            .WithOne(w => w.User)
            .HasForeignKey<Wallet>(w => w.UserId);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.FromWallet)
            .WithMany()
            .HasForeignKey(t => t.FromWalletId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.ToWallet)
            .WithMany()
            .HasForeignKey(t => t.ToWalletId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 