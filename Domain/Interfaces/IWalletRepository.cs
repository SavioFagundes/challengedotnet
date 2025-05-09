using WalletAPI.Domain.Models;

namespace WalletAPI.Domain.Interfaces;

public interface IWalletRepository : IGenericRepository<Wallet>
{
    Task<Wallet> GetByUserIdAsync(int userId);
    Task<decimal> GetBalanceAsync(int walletId);
    Task UpdateBalanceAsync(int walletId, decimal amount);
} 