using Shared.Core.Enums;
using Transactions.Core.Enums;

namespace Transactions.Application.Contracts.Responses
{
    public class CardItemResponse
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public List<Tuple<CurrencyId, decimal>> BalanceAccounts { get; set; }
        public string HolderName { get; set; }
        public DateOnly ValidityDate { get; set; }
        public PaymentNetwrok Network { get; set; }
    }
}