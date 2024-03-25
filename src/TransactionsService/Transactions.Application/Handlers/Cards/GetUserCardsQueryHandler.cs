using Microsoft.EntityFrameworkCore;
using Shared.Core.Abstractions;
using Transactions.Application.Contracts.Responses;
using Transactions.Core.Enums;
using Transactions.Persistance;

namespace Transactions.Application.Handlers.Cards
{
    public class GetUserCardsQueryHandler : IHandlerAsync<List<CardItemResponse>, Guid>
    {
        private ApplicationContext _context;
        public GetUserCardsQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<CardItemResponse>> HandleAsync(Guid request)
        {
            var cards = await Task.Run(async () => await _context.Cards
            .Where(c => c.UserId == request)
            .Include(x => x.CurrencyAccounts)
            .ToListAsync());

            var response = cards?.Select(x => new CardItemResponse
            {
                Id = x.Id,
                Number = x.Number,
                BalanceAccounts = x.CurrencyAccounts
                .Select(x => new Tuple<CurrencyType, decimal>(x.Currency, x.Balance))
                .ToList(),
                HolderName = x.HolderName,
                ValidityDate = x.Validity,
                Network = x.PaymentNetwrok
            }).ToList() ?? new List<CardItemResponse>();

            return response;
        }
    }
}