using Shared.Core.Enums;
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
        public CurrencyId Currency { get; set; }
            = CurrencyId.None;
        public TransactionType Type { get; set; }
            = TransactionType.None;
        public TransationDirect Direct { get; set; }
            = TransationDirect.None;
    }
}
