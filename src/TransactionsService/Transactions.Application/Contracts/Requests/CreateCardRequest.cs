using Transactions.Core.Enums;

namespace Transactions.Application.Contracts.Requests
{
    public class CreateCardRequest
    {
        public Guid UserId { get; set; }
        public string Number { get; set; }
        public List<Tuple<CurrencyType, decimal>> BalanceAccounts { get; set; }
        public string HolderName { get; set; }
        public string ValidityData { get; set; }
        public string BankName { get; set; }
        public PaymentNetwrok Network { get; set; }
    }
}