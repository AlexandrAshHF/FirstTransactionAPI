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
        public TransactionEntity()
        {
            SenderCard = new CardEntity();
            ConsumerCard = new CardEntity();
        }
        public Guid Id { get; private set; }
            = Guid.Empty;
        public Guid SenderCardId { get; private set; }
            = Guid.Empty;
        public CardEntity SenderCard { get; private set; } =
            new CardEntity();
        public Guid ConsumerCardId { get; private set; }
            = Guid.Empty;
        public CardEntity ConsumerCard { get; private set; }
            = new CardEntity();
        public decimal TransferAmount { get; private set; }
            = decimal.Zero;
        public TransactionStatus Status { get; private set; }
            = TransactionStatus.None;
        public CurrencyType Currency { get; private set; }
            = CurrencyType.None;
        public TransactionType Type { get; private set; }
            = TransactionType.None;
    }
}