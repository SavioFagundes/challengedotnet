using Microsoft.EntityFrameworkCore;
using WalletAPI.Domain.Interfaces;
using WalletAPI.Domain.Models;
using WalletAPI.Infrastructure.Data;

namespace WalletAPI.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(WalletDbContext context) : base(context)
    {
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserWithWalletAsync(int userId)
    {
        return await _dbSet
            .Include(u => u.Wallet)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _dbSet.AnyAsync(u => u.Email == email);
    }
} 