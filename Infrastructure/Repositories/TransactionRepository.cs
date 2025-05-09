using Microsoft.EntityFrameworkCore;
using WalletAPI.Domain.Interfaces;
using WalletAPI.Domain.Models;
using WalletAPI.Infrastructure.Data;

namespace WalletAPI.Infrastructure.Repositories;

public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(WalletDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Transaction>> GetUserTransactionsAsync(int userId, DateTime? startDate = null, DateTime? endDate = null)
    {
        var query = _dbSet
            .Include(t => t.FromWallet)
                .ThenInclude(w => w.User)
            .Include(t => t.ToWallet)
                .ThenInclude(w => w.User)
            .Where(t => t.FromWallet.UserId == userId || t.ToWallet.UserId == userId);

        if (startDate.HasValue)
            query = query.Where(t => t.Timestamp >= startDate.Value);

        if (endDate.HasValue)
            query = query.Where(t => t.Timestamp <= endDate.Value);

        return await query.OrderByDescending(t => t.Timestamp).ToListAsync();
    }

    public async Task<IEnumerable<Transaction>> GetWalletTransactionsAsync(int walletId, DateTime? startDate = null, DateTime? endDate = null)
    {
        var query = _dbSet
            .Include(t => t.FromWallet)
                .ThenInclude(w => w.User)
            .Include(t => t.ToWallet)
                .ThenInclude(w => w.User)
            .Where(t => t.FromWalletId == walletId || t.ToWalletId == walletId);

        if (startDate.HasValue)
            query = query.Where(t => t.Timestamp >= startDate.Value);

        if (endDate.HasValue)
            query = query.Where(t => t.Timestamp <= endDate.Value);

        return await query.OrderByDescending(t => t.Timestamp).ToListAsync();
    }

    public async Task<bool> HasEnoughBalanceAsync(int walletId, decimal amount)
    {
        var wallet = await _context.Wallets.FindAsync(walletId);
        return wallet != null && wallet.Balance >= amount;
    }
} 