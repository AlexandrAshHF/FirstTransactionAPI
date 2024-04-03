using Shared.Core.Enums;
using Transactions.Core.Enums;

namespace Transactions.Core.Entities
{
    public class TransactionEntity
    {
        public TransactionEntity(Guid id, Guid senderCardId, CardEntity senderCard,
            Guid consumerCardId, CardEntity consumerCard, decimal sendAmount, decimal receiveAmount, 
            CurrencyId currencySender, CurrencyId currencyConsumer, DateTime time)
        {
            Id = id;
            SenderCardId = senderCardId;
            SenderCard = senderCard;
            ConsumerCardId = consumerCardId;
            ConsumerCard = consumerCard;
            SendAmount = sendAmount;
            ReceiveAmount = receiveAmount;
            CurrencySender = currencySender;
            CurrencyConsumer = currencyConsumer;
            TimeOfCreate = time;
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
        public decimal SendAmount { get; private set; }
            = decimal.Zero;
        public decimal ReceiveAmount { get; private set; }
            = decimal.Zero;
        public CurrencyId CurrencySender { get; private set; }
            = CurrencyId.None;
        public CurrencyId CurrencyConsumer { get; private set; }
            = CurrencyId.None;
        public DateTime TimeOfCreate { get; private set; }
    }
}