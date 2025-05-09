using WalletAPI.Application.Dtos.Transaction;
using WalletAPI.Domain.Interfaces;
using WalletAPI.Domain.Interfaces.Services;
using WalletAPI.Domain.Models;

namespace WalletAPI.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly IUserRepository _userRepository;

    public TransactionService(
        ITransactionRepository transactionRepository,
        IWalletRepository walletRepository,
        IUserRepository userRepository)
    {
        _transactionRepository = transactionRepository;
        _walletRepository = walletRepository;
        _userRepository = userRepository;
    }

    public async Task<Transaction> CreateTransactionAsync(int fromUserId, CreateTransactionDto transactionDto)
    {
        var fromUser = await _userRepository.GetUserWithWalletAsync(fromUserId);
        if (fromUser?.Wallet == null)
            throw new Exception("Usuário remetente não encontrado");

        var toUser = await _userRepository.GetUserWithWalletAsync(transactionDto.ToUserId);
        if (toUser?.Wallet == null)
            throw new Exception("Usuário destinatário não encontrado");

        if (!await _transactionRepository.HasEnoughBalanceAsync(fromUser.Wallet.Id, transactionDto.Amount))
            throw new Exception("Saldo insuficiente");

        var transaction = new Transaction
        {
            FromWalletId = fromUser.Wallet.Id,
            ToWalletId = toUser.Wallet.Id,
            Amount = transactionDto.Amount,
            Timestamp = DateTime.UtcNow
        };

        await _transactionRepository.AddAsync(transaction);
        await _walletRepository.UpdateBalanceAsync(fromUser.Wallet.Id, -transactionDto.Amount);
        await _walletRepository.UpdateBalanceAsync(toUser.Wallet.Id, transactionDto.Amount);

        return transaction;
    }

    public async Task<IEnumerable<Transaction>> GetUserTransactionsAsync(int userId, DateTime? startDate = null, DateTime? endDate = null)
    {
        return await _transactionRepository.GetUserTransactionsAsync(userId, startDate, endDate);
    }
} 