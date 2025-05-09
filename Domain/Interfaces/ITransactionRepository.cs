using WalletAPI.Domain.Models;

namespace WalletAPI.Domain.Interfaces;

public interface ITransactionRepository : IGenericRepository<Transaction>
{
    Task<IEnumerable<Transaction>> GetUserTransactionsAsync(int userId, DateTime? startDate = null, DateTime? endDate = null);
    Task<IEnumerable<Transaction>> GetWalletTransactionsAsync(int walletId, DateTime? startDate = null, DateTime? endDate = null);
    Task<bool> HasEnoughBalanceAsync(int walletId, decimal amount);
} 