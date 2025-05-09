using System.ComponentModel.DataAnnotations;

namespace WalletAPI.Application.Dtos.Transaction;

public class CreateTransactionDto
{
    [Required]
    public int ToUserId { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
    public decimal Amount { get; set; }
} 