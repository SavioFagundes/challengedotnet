using System.ComponentModel.DataAnnotations;

namespace WalletAPI.Application.Dtos.Auth;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
} 