using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Transactions.Application.Contracts.Requests;
using Transactions.Application.Contracts.Responses;
using Transactions.Core.Entities;
using Transactions.Core.ValidationRules;
using Transactions.Persistance;

namespace Transactions.Application.Implementation
{
    public class CardsService
    {
        private ApplicationContext _context;
        private CardValidator _validator;
        public CardsService(ApplicationContext context)
        {
            _context = context;
            _validator = new CardValidator();
        }
        public async Task<List<CardItemResponse>> GetCardsListByUserId(Guid id)
        {
            var cards = await Task.Run(async () => await _context.Cards.Where(c => c.UserId == id).ToListAsync());

            var response = cards?.Select(x => new CardItemResponse
            {
                Id = x.Id,
                Number = x.Number,
                BalanceAccounts = x.CurrencyAccounts,
                HolderName = x.HolderName,
                ValidityDate = x.Validity,
                Network = x.PaymentNetwrok
            }).ToList() ?? new List<CardItemResponse>();

            return response;
        }
        public async Task<FullCardResponse> GetDetailCardById(Guid cardId)
        {
            var card = await _context.Cards.FindAsync(cardId);

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
        public async Task<ValidationResult> UpdateCard(RefillCardRequest request)
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
        public async Task<ValidationResult> CreateCard(CreateCardRequest request, Guid userId)
        {
            Random random = new Random();
            string cvv = random.Next(100, 999).ToString();

            var card = new CardEntity(Guid.NewGuid(), request.HolderName, request.BankName, request.Number, cvv,
                request.ValidityData, request.BalanceAccounts, request.Network, userId, new List<TransactionEntity>());

            var result = _validator.Validate(card);

            if (result.IsValid)
            {
                await _context.AddAsync(card);
                await _context.SaveChangesAsync();
            }

            return result;
        }
        public async Task<Guid> DeleteCard(Guid id)
        {
            var card = await _context.Cards.FindAsync(id);

            if (card == null)
                return Guid.Empty;

            _context.Remove(card);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}