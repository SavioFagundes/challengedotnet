using WalletAPI.Application.Dtos.Transaction;
using WalletAPI.Domain.Models;

namespace WalletAPI.Domain.Interfaces.Services;

public interface ITransactionService
{
    Task<Transaction> CreateTransactionAsync(int fromUserId, CreateTransactionDto transactionDto);
    Task<IEnumerable<Transaction>> GetUserTransactionsAsync(int userId, DateTime? startDate = null, DateTime? endDate = null);
} 