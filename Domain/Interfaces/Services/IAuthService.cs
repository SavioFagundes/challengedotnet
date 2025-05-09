using WalletAPI.Application.Dtos.Auth;

namespace WalletAPI.Domain.Interfaces.Services;
 
public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto registerDto);
    Task<string> LoginAsync(LoginDto loginDto);
} 