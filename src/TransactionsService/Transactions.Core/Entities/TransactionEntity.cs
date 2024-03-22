using Transactions.Core.Enums;

namespace Transactions.Core.Entities
{
    public class TransactionEntity
    {
        public TransactionEntity(Guid id, Guid sednerCardId, Guid consumerCardId, 
            decimal transferAmount, TransactionStatus status, CurrencyType currency, 
            TransactionType type)
        {
            Id = id;
            SednerCardId = sednerCardId;
            ConsumerCardId = consumerCardId;
            TransferAmount = transferAmount;
            Status = status;
            Currency = currency;
            Type = type;
        }

        public Guid Id { get; private set; }
        public Guid SednerCardId { get; private set; }
        public Guid ConsumerCardId { get; private set; }
        public decimal TransferAmount { get; private set; }
        public TransactionStatus Status { get; private set; }
        public CurrencyType Currency { get; private set; }
        public TransactionType Type { get; private set; }
    }
}