using Shared.Core.Abstractions;
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
            var card = await _context.Cards.FindAsync(request);

            if (card == null)
                return new FullCardResponse();

            var response = new FullCardResponse
            {
                Id = card.Id,
                BalanceAccounts = card.CurrencyAccounts,
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
