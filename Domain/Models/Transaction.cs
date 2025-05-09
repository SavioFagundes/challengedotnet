using System;
using System.ComponentModel.DataAnnotations;

namespace WalletAPI.Domain.Models;

public class Transaction
{
    public int Id { get; set; }
    [Required]
    public int FromWalletId { get; set; }
    [Required]
    public int ToWalletId { get; set; }
    [Required]
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    public Wallet? FromWallet { get; set; }
    public Wallet? ToWallet { get; set; }
}