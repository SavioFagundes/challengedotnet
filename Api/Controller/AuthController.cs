using Microsoft.AspNetCore.Mvc;
using WalletAPI.Application.Dtos.Auth;
using WalletAPI.Infrastructure.Data;

namespace WalletAPI.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly WalletDbContext _context;

    public AuthController(WalletDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        // TODO: Implementar login
        return Ok();
    }
} 