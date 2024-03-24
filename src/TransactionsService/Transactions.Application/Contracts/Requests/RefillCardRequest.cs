using Transactions.Core.Enums;

namespace Transactions.Application.Contracts.Requests
{
    public class RefillCardRequest
    {
        public Guid CardId { get; set; }
        public List<Tuple<CurrencyType, decimal>> BalanceAccounts { get; set; }
    }
}