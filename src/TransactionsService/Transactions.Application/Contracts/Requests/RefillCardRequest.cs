using Shared.Core.Enums;

namespace Transactions.Application.Contracts.Requests
{
    public class RefillCardRequest
    {
        public Guid CardId { get; set; }
        public List<Tuple<CurrencyId, decimal>> BalanceAccounts { get; set; }
    }
}