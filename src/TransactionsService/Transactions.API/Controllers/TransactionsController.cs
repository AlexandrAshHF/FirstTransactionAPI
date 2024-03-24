using Microsoft.AspNetCore.Mvc;
using Transactions.Application.Contracts.Requests;
using Transactions.Application.Contracts.Responses;

namespace Transactions.API.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {

        [HttpGet("transactions-list")]
        public IActionResult GetAllTransactions()
        {
            return Ok(new List<TransactionItemResponse>());
        }

        [HttpGet("transactions-list/{cardId}")]
        public IActionResult GetCardTransactions(Guid cardId)
        {
            return Ok(new List<TransactionItemResponse>());
        }

        [HttpGet("transaction-detail")]
        public IActionResult GetTransactionDetail(Guid transactionId)
        {
            return Ok(new TransactionDetailResponse());
        }

        [HttpPost("produce-transaction")]
        public IActionResult CreateTransaction(CreateTransactionRequest request)
        {
            return Ok(Guid.Empty);
        }
    }
}