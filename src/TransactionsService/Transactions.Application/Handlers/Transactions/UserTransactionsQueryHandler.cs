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
            List<TransactionItemResponse> response = new List<TransactionItemResponse>();

            List<Guid> cardsId = request.CardId == null
                ?
                await _context.Cards
                .Where(x => x.UserId == request.UserId)
                .Select(x => x.Id).ToListAsync()
                :
                new List<Guid>() { request.CardId ?? throw new ArgumentNullException() };


            cardsId.ForEach(async (item) =>
            {
                response.AddRange(
                    await _context.Transactions
                    .Where(x => x.Direct == request.Direct)
                    .Skip((request.Page*request.Number)/cardsId.Count)
                    .Include(x => x.SenderCard)
                    .Include(x => x.ConsumerCard)
                    .Where(x => x.ConsumerCardId == item || x.SenderCardId == item)
                    .Select(x => new TransactionItemResponse
                        {
                            Id = x.Id,
                            SenderNumber = x.SenderCard.Number,
                            ConsumerNumber = x.ConsumerCard.Number,
                            Amount = x.TransferAmount,
                            Status = x.Status,
                            Currency = x.Currency,
                            Type = x.Type,
                        }).ToListAsync());
            });

            return response;
        }
    }
}
