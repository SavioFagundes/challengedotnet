using System.ComponentModel.DataAnnotations;

namespace WalletAPI.Domain.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public required string FullName { get; set; }

    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string PasswordHash { get; set; }

    public Wallet? Wallet { get; set; }
}