using WalletAPI.Application.Dtos.Wallet;
using WalletAPI.Domain.Interfaces;
using WalletAPI.Domain.Interfaces.Services;

namespace WalletAPI.Application.Services;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;
    private readonly IUserRepository _userRepository;

    public WalletService(IWalletRepository walletRepository, IUserRepository userRepository)
    {
        _walletRepository = walletRepository;
        _userRepository = userRepository;
    }

    public async Task<decimal> GetBalanceAsync(int userId)
    {
        var user = await _userRepository.GetUserWithWalletAsync(userId);
        if (user?.Wallet == null)
            throw new Exception("Usuário não encontrado");

        return user.Wallet.Balance;
    }

    public async Task<decimal> DepositAsync(int userId, DepositDto depositDto)
    {
        var user = await _userRepository.GetUserWithWalletAsync(userId);
        if (user?.Wallet == null)
            throw new Exception("Usuário não encontrado");

        await _walletRepository.UpdateBalanceAsync(user.Wallet.Id, depositDto.Amount);
        return user.Wallet.Balance + depositDto.Amount;
    }
} 