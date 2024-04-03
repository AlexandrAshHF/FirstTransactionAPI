using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Transactions.Application.Contracts.Requests;
using Transactions.Application.Handlers.Transactions;

namespace Transactions.API.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {

        [HttpGet("transactions-list")]
        public async Task<IActionResult> GetTransactions([FromServices] UserTransactionsQueryHandler handler, [FromQuery] GetTransactionsRequest request)
        {
            //var userClaims = User.Identity as ClaimsIdentity;
            //var userId = userClaims?.FindFirst("userId")?.Value ?? throw new NullReferenceException();

            

            var result = await handler.HandleAsync(request);

            return Ok(result);
        }

        [HttpGet("transaction-detail/{transactionId}")]
        public async Task<IActionResult> GetTransactionDetail([FromServices] DetailTransactionQueryHandler handler,
            [FromRoute] Guid transactionId)
        {
            return Ok(await handler.HandleAsync(transactionId));
        }

        [HttpPost("produce-transaction")]
        public async Task<IActionResult> CreateTransaction(
            [FromServices] CardsTransactionCommandHandler handler,
            [FromBody] CardsTransactionRequest request)
        {
            var response = await handler.HandleAsync(request);
            return Ok(response);
        }
    }
}