using System.ComponentModel.DataAnnotations;

namespace WalletAPI.Application.Dtos.Wallet;

public class DepositDto
{
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
    public decimal Amount { get; set; }
} 