using Microsoft.EntityFrameworkCore;
using Shared.Core.Abstractions;
using Transactions.Application.Contracts.Responses;
using Transactions.Core.Entities;
using Transactions.Persistance;

namespace Transactions.Application.Handlers.Transactions
{
    public class DetailTransactionQueryHandler : IHandlerAsync<TransactionDetailResponse, Guid>
    {
        private ApplicationContext _context;
        public DetailTransactionQueryHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<TransactionDetailResponse> HandleAsync(Guid request)
        {
            TransactionEntity transaction = await _context.Transactions
                .Include(x => x.SenderCard)
                .Include(x => x.ConsumerCard)
                .FirstAsync();

            return new TransactionDetailResponse
            {
                Id = transaction.Id,
                SenderCard = transaction.SenderCard,
                ConsumerCard = transaction.ConsumerCard,
                ConsumerCardId = transaction.ConsumerCardId,
                Currency = transaction.CurrencySender,
                SenderCardId = transaction.SenderCardId,
                Direct = transaction.Direct,
                Status = transaction.Status,
                TransferAmount = transaction.TransferAmount,
                Type = transaction.Type,
            };
        }
    }
}
