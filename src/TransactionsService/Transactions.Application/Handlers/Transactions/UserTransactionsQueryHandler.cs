using Microsoft.EntityFrameworkCore;
using Shared.Core.Abstractions;
using Transactions.Application.Contracts.Requests;
using Transactions.Application.Contracts.Responses;
using Transactions.Persistance;

namespace Transactions.Application.Handlers.Transactions
{
    public class UserTransactionsQueryHandler : IHandlerAsync<List<TransactionItemResponse>, GetTransactionsRequest>
    {
        private ApplicationContext _context;
        public UserTransactionsQueryHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<TransactionItemResponse>> HandleAsync(GetTransactionsRequest request)
        {
            var consumerTransactions = await _context.Transactions
                .AsNoTracking()
                .Include(x => x.ConsumerCard)
                .Where(x => request.UserId == x.ConsumerCard.UserId)
                .Skip(request.Page * request.Number)
                .Take(request.Number)
                .ToListAsync();

            var senderTransactions = await _context.Transactions
                .AsNoTracking()
                .Include(x => x.SenderCard)
                .Where(x => request.UserId == x.SenderCard.UserId)
                .Skip(request.Page * request.Number)
                .Take(request.Number)
                .ToListAsync();

            List<TransactionItemResponse> response = await Task.Run( () => consumerTransactions
                .Concat(senderTransactions)
                .OrderBy(x => x.TimeOfCreate)
                .Take(request.Number)
                .Select(x => new TransactionItemResponse
                {
                    Id = x.Id,
                    SenderNumber = x.SenderCard.Number,
                    ConsumerNumber = x.ConsumerCard.Number,
                    Amount = x.SendAmount,
                    SenderCurrency = x.CurrencySender,
                    ConsumerCurrency = x.CurrencyConsumer,
                }).ToList());

            return response;
        }
    }
}