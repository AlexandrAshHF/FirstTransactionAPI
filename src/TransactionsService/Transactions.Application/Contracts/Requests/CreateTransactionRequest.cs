using Transactions.Core.Enums;

namespace Transactions.Application.Contracts.Requests
{
    public class CreateTransactionRequest
    {
        public Guid SenderId { get; set; }
        public string ConsumerNumber { get; set; }
        public TransactionStatus Status { get; set; }
        public CurrencyType Currency { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
    }
}
