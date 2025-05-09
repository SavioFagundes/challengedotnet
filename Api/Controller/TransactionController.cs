using Microsoft.AspNetCore.Mvc;
using WalletAPI.Application.Dtos.Transaction;

namespace WalletAPI.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTransaction(CreateTransactionDto createTransactionDto)
    {
        // TODO: Implementar criação de transação
        var transation = 
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactions([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        // TODO: Implementar listagem de transações
        return Ok();
    }
} 