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
                .FirstAsync();

            return new TransactionDetailResponse
            {
                Id = transaction.Id,
                SenderCard = transaction.SenderCard,
                ConsumerCard = transaction.ConsumerCard,
                ConsumerCardId = transaction.ConsumerCardId,
                SenderCurrency = transaction.CurrencySender,
                ConsumerCurrency = transaction.CurrencyConsumer,
                TransferAmount = transaction.SendAmount,
                SenderCardId = transaction.SenderCardId,
            };
        }
    }
}
