using WalletAPI.Application.Dtos.Wallet;

namespace WalletAPI.Domain.Interfaces.Services;
 
public interface IWalletService
{
    Task<decimal> GetBalanceAsync(int userId);
    Task<decimal> DepositAsync(int userId, DepositDto depositDto);
} 