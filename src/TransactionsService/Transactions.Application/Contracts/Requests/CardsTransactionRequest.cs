using Transactions.Core.Enums;

namespace Transactions.Application.Contracts.Requests
{
    public class CardsTransactionRequest
    {
        public Guid SenderId { get; set; }
        public string ConsumerNumber { get; set; }
        public CurrencyType Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
