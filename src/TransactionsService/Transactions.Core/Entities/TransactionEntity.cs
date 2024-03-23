using Transactions.Core.Enums;

namespace Transactions.Core.Entities
{
    public class TransactionEntity
    {
        public TransactionEntity(Guid id, Guid senderCardId, CardEntity senderCard,
            Guid consumerCardId, CardEntity consumerCard, decimal transferAmount,
            TransactionStatus status, CurrencyType currency, TransactionType type)
        {
            Id = id;
            SenderCardId = senderCardId;
            SenderCard = senderCard;
            ConsumerCardId = consumerCardId;
            ConsumerCard = consumerCard;
            TransferAmount = transferAmount;
            Status = status;
            Currency = currency;
            Type = type;
        }

        public Guid Id { get; private set; }
        public Guid SenderCardId { get; private set; }
        public CardEntity SenderCard { get; private set; }
        public Guid ConsumerCardId { get; private set; }
        public CardEntity ConsumerCard { get; private set; }
        public decimal TransferAmount { get; private set; }
        public TransactionStatus Status { get; private set; }
        public CurrencyType Currency { get; private set; }
        public TransactionType Type { get; private set; }
    }
}