using Microsoft.EntityFrameworkCore;
using WalletAPI.Domain.Interfaces;
using WalletAPI.Domain.Models;
using WalletAPI.Infrastructure.Data;

namespace WalletAPI.Infrastructure.Repositories;

public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
{
    public WalletRepository(WalletDbContext context) : base(context)
    {
    }

    public async Task<Wallet> GetByUserIdAsync(int userId)
    {
        return await _dbSet.FirstOrDefaultAsync(w => w.UserId == userId);
    }

    public async Task<decimal> GetBalanceAsync(int walletId)
    {
        var wallet = await _dbSet.FindAsync(walletId);
        return wallet?.Balance ?? 0;
    }

    public async Task UpdateBalanceAsync(int walletId, decimal amount)
    {
        var wallet = await _dbSet.FindAsync(walletId);
        if (wallet != null)
        {
            wallet.Balance += amount;
            _dbSet.Update(wallet);
        }
    }
} 