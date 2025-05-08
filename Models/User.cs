using System.ComponentModel.DataAnnotations;

namespace WalletAPI.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    public Wallet Wallet { get; set; }
}