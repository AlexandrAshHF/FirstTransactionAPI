using Microsoft.EntityFrameworkCore;
using Shared.Core.Abstractions;
using Shared.Core.Enums;
using Transactions.Application.Contracts.Responses;
using Transactions.Persistance;

namespace Transactions.Application.Handlers.Cards
{
    public class GetDetailCardQueryHandler : IHandlerAsync<FullCardResponse, Guid>
    {
        private ApplicationContext _context;
        public GetDetailCardQueryHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<FullCardResponse> HandleAsync(Guid request)
        {
            var card = await Task.Run(async () => await _context.Cards
                .AsNoTracking()
                .Include(x => x.CurrencyAccounts)
                .Where(x => x.Id == request)
                .FirstAsync());

            if (card == null)
                return new FullCardResponse();

            var response = new FullCardResponse
            {
                Id = card.Id,

                BalanceAccounts = card.CurrencyAccounts
                .Select(x => new Tuple<CurrencyId, decimal>(x.Currency, x.Balance))
                .ToList(),

                Number = card.Number,
                ValidityData = card.Validity,
                BankName = card.BankName,
                CVV = card.AuthenticityCode,
                HolderName = card.HolderName,
                Network = card.PaymentNetwrok
            };

            return response;
        }
    }
}
