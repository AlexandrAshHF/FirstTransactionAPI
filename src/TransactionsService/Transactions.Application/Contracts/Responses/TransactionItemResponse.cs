using Shared.Core.Enums;
using Transactions.Core.Enums;

namespace Transactions.Application.Contracts.Responses
{
    public class TransactionItemResponse
    {
        public Guid Id { get; set; }
        public string SenderNumber { get; set; }
        public string ConsumerNumber { get; set; }
        public TransactionType Type { get; set; }
        public CurrencyId Currency { get; set; }
        public TransactionStatus Status { get; set; }
        public decimal Amount { get; set; }
    }
}
