using Shared.Core.Enums;
using Transactions.Core.Enums;

namespace Transactions.Application.Contracts.Responses
{
    public class TransactionItemResponse
    {
        public Guid Id { get; set; }
        public string SenderNumber { get; set; }
        public string ConsumerNumber { get; set; }
        public CurrencyId ConsumerCurrency { get; set; }
        public CurrencyId SenderCurrency { get; set; }
        public decimal Amount { get; set; }
    }
}
