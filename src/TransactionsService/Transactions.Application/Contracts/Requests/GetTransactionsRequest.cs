using Transactions.Core.Enums;

namespace Transactions.Application.Contracts.Requests
{
    public class GetTransactionsRequest
    {
        public Guid? UserId { get; set; }
        public Guid? CardId { get; set; }
        public int Page { get; set; }
        public int Number { get; set; }
    }
}
