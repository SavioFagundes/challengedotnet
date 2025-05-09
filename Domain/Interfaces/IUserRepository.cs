using WalletAPI.Domain.Models;

namespace WalletAPI.Domain.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<User> GetUserWithWalletAsync(int userId);
    Task<bool> EmailExistsAsync(string email);
} 