using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Shared.Core.Abstractions;
using Transactions.Application.Contracts.Requests;
using Transactions.Core.Entities;
using Transactions.Core.ValidationRules;
using Transactions.Persistance;

namespace Transactions.Application.Handlers.Cards
{
    public class UpdateCardCommandHandler : IHandlerAsync<ValidationResult, RefillCardRequest>
    {
        private ApplicationContext _context;
        private CardValidator _validator;
        public UpdateCardCommandHandler(ApplicationContext context)
        {
            _context = context;
            _validator = new CardValidator();
        }
        public async Task<ValidationResult> HandleAsync(RefillCardRequest request)
        {
            var currentCard = await _context.Cards.FindAsync(request.CardId);

            if (currentCard == null)
                return new ValidationResult();

            var card = new CardEntity(currentCard.Id, currentCard.HolderName, currentCard.BankName, currentCard.Number, currentCard.AuthenticityCode,
                currentCard.Validity, request.BalanceAccounts, currentCard.PaymentNetwrok, currentCard.UserId, null);

            ValidationResult result = (await _validator.ValidateAsync(card)) ?? throw new NullReferenceException($"Validator {_validator} returned null");

            if (result.IsValid)
            {
                _context.Attach(card);
                _context.Entry(card).Property(e => e.CurrencyAccounts).IsModified = true;
                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}