using Transactions.Core.Entities;
using Transactions.Core.Enums;

namespace Transactions.Application.Contracts.Responses
{
    public class TransactionDetailResponse
    {
        public Guid Id { get; set; }
            = Guid.Empty;
        public Guid SenderCardId { get; set; }
            = Guid.Empty;
        public CardEntity SenderCard { get; set; } =
            new CardEntity();
        public Guid ConsumerCardId { get; set; }
            = Guid.Empty;
        public CardEntity ConsumerCard { get; set; }
            = new CardEntity();
        public decimal TransferAmount { get; set; }
            = decimal.Zero;
        public TransactionStatus Status { get; set; }
            = TransactionStatus.None;
        public CurrencyType Currency { get; set; }
            = CurrencyType.None;
        public TransactionType Type { get; set; }
            = TransactionType.None;
        public TransactionDirect Direct { get; set; }
            = TransactionDirect.None;
    }
}
