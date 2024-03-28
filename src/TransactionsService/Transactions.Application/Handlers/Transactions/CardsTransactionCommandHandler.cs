using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Shared.Core.Abstractions;
using Transactions.Application.Contracts.Requests;
using Transactions.Core.Entities;
using Transactions.Core.Enums;
using Transactions.Persistance;

namespace Transactions.Application.Handlers.Transactions
{
    public class CardsTransactionCommandHandler : IHandlerAsync<string, CardsTransactionRequest>
    {
        private ApplicationContext _context;
        public CardsTransactionCommandHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<string> HandleAsync(CardsTransactionRequest request)
        {
            CardEntity FirstCard = (await _context.Cards
                .Include(x => x.CurrencyAccounts)
                .FirstAsync(x => x.Id == request.SenderId))
                ?? throw new ArgumentNullException();

            var SecondCard = await _context.Cards
                .Where(x => x.Number == request.ConsumerNumber)
                .Include(x => x.CurrencyAccounts)
                .FirstOrDefaultAsync();

            if (SecondCard == null
                || request.Amount > FirstCard.CurrencyAccounts.First(x => x.Currency == request.Currency).Balance)
                    return $"Incorrect data in request";

            bool existCurrency = false;
            SecondCard.CurrencyAccounts.ForEach(item =>
            {
                if (item.Currency == request.Currency)
                    existCurrency = true;
            });

            if (existCurrency)
            {
                TransactionEntity transaction = new TransactionEntity(Guid.NewGuid(), FirstCard.Id,
                    FirstCard, SecondCard.Id, SecondCard,
                    request.Amount, TransactionStatus.Success,
                    request.Currency, TransactionType.CardToCard);

                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();
            }
            else
            {
                //gRPC коннект с котировками и получение скейла и рейтинга для вычислений
            }

            return string.Empty;
        }
    }
}
