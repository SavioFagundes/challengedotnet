using Microsoft.AspNetCore.Mvc;
using WalletAPI.Application.Dtos.Wallet;

namespace WalletAPI.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class WalletController : ControllerBase
{
    [HttpGet("balance")]
    public async Task<IActionResult> GetBalance()
    {
        // TODO: Implementar consulta de saldo
        
        return Ok();
    }

    [HttpPost("deposit")]
    public async Task<IActionResult> Deposit(DepositDto depositDto)
    {
        // TODO: Implementar depósito
        return Ok();
    }
} 