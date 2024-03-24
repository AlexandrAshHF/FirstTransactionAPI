using FluentValidation;
using Transactions.Core.Entities;

namespace Transactions.Core.ValidationRules
{
    public class CardValidator : AbstractValidator<CardEntity>
    {
        public CardValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                .When(card => card.Id != Guid.Empty);

            RuleFor(x => x.AuthenticityCode).NotEmpty()
                .When(x => x.AuthenticityCode.Length == 3 && Int32.TryParse(x.AuthenticityCode, out int _))
                .WithMessage("Incorrect code format")
                .WithName(nameof(CardEntity.AuthenticityCode));

            RuleFor(x => x.CurrencyAccounts).NotEmpty()
                .WithMessage("There must be at least one currency")
                .WithName(nameof(CardEntity.CurrencyAccounts));

            RuleFor(x => x.BankName).NotEmpty()
                .WithMessage("Property bank name cannot be empty")
                .WithName(nameof(CardEntity.BankName));

            RuleFor(x => x.Validity).NotEmpty()
                .When(card => card.Validity > DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage("The card's expiration date can only be in the future tense")
                .WithName(nameof(CardEntity.Validity));
        }
    }
}
