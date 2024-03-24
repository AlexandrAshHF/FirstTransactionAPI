using FluentValidation;
using Transactions.Core.Entities;

namespace Transactions.Core.ValidationRules
{
    public class TransactionValidator : AbstractValidator<TransactionEntity>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.SenderCardId).NotEmpty()
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage("Sender should be specified");

            RuleFor(x => x.ConsumerCardId).NotEmpty()
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage("Consumer should be specified");

            RuleFor(x => x.Id).NotEmpty()
                .NotNull()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.Status).NotEmpty()
                .NotNull()
                .WithMessage("Tranasction status should be specified")
                .WithName(nameof(TransactionEntity.Status));
        }
    }
}
