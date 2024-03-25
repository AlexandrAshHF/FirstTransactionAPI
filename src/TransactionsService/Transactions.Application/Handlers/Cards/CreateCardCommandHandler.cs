using FluentValidation.Results;
using Shared.Core.Abstractions;
using Transactions.Application.Contracts.Requests;
using Transactions.Core.Entities;
using Transactions.Core.ValidationRules;
using Transactions.Persistance;

namespace Transactions.Application.Handlers.Cards
{
    public class CreateCardCommandHandler : IHandlerAsync<ValidationResult, CreateCardRequest>
    {
        private ApplicationContext _context;
        private CardValidator _validator;
        public CreateCardCommandHandler(ApplicationContext context)
        {
            _context = context;
            _validator = new CardValidator();
        }
        public async Task<ValidationResult> HandleAsync(CreateCardRequest request)
        {
            Random random = new Random();
            string cvv = random.Next(100, 999).ToString();

            var card = new CardEntity(Guid.NewGuid(), request.HolderName, request.BankName, request.Number, cvv,
                DateOnly.Parse(request.ValidityData), request.BalanceAccounts, request.Network, request.UserId, new List<TransactionEntity>(), new List<TransactionEntity>());

            var result = _validator.Validate(card);

            if (result.IsValid)
            {
                await _context.AddAsync(card);
                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}