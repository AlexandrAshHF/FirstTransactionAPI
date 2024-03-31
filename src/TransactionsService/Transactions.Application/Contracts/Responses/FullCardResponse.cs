using Shared.Core.Enums;
using Transactions.Core.Enums;

namespace Transactions.Application.Contracts.Responses
{
    public class FullCardResponse
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public List<Tuple<CurrencyId, decimal>> BalanceAccounts { get; set; }
        public string HolderName { get; set; }
        public DateOnly ValidityData { get; set; }
        public string CVV { get; set; }
        public PaymentNetwrok Network { get; set; }
        public string BankName { get; set; }
    }
}
