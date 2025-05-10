using Microsoft.EntityFrameworkCore;
using WalletAPI.Domain.Models;
using BCrypt.Net;

namespace WalletAPI.Infrastructure.Data;

public static class DbInitializer
{
    public static async Task Initialize(WalletDbContext context)
    {
        // Verifica se já existem dados
        if (context.Users.Any())
            return;

        // Adiciona usuários de teste
        var users = new List<User>
        {
            new User 
            { 
                FullName = "João Silva",
                Email = "joao@email.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("senha123")
            },
            new User 
            { 
                FullName = "Maria Santos",
                Email = "maria@email.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("senha456")
            },
            new User 
            { 
                FullName = "Pedro Oliveira",
                Email = "pedro@email.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("senha789")
            }
        };

        await context.Users.AddRangeAsync(users);
        await context.SaveChangesAsync();

        // Adiciona carteiras para os usuários
        var wallets = new List<Wallet>
        {
            new Wallet 
            { 
                UserId = 1,
                Balance = 1000.00m
            },
            new Wallet 
            { 
                UserId = 2,
                Balance = 500.00m
            },
            new Wallet 
            { 
                UserId = 3,
                Balance = 750.00m
            }
        };

        await context.Wallets.AddRangeAsync(wallets);
        await context.SaveChangesAsync();

        // Adiciona algumas transações de exemplo
        var transactions = new List<Transaction>
        {
            new Transaction 
            { 
                FromWalletId = 1,
                ToWalletId = 2,
                Amount = 100.00m,
                Timestamp = DateTime.UtcNow.AddDays(-2)
            },
            new Transaction 
            { 
                FromWalletId = 2,
                ToWalletId = 3,
                Amount = 50.00m,
                Timestamp = DateTime.UtcNow.AddDays(-1)
            },
            new Transaction 
            { 
                FromWalletId = 3,
                ToWalletId = 1,
                Amount = 75.00m,
                Timestamp = DateTime.UtcNow
            }
        };

        await context.Transactions.AddRangeAsync(transactions);
        await context.SaveChangesAsync();
    }
} 