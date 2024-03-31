using Shared.Core.Enums;

namespace Transactions.Core.Entities
{
    public class CurrencyAccount
    {
        public CurrencyAccount(Guid id, Guid cardId, CardEntity card, CurrencyId type, decimal balance)
        {
            Id = id;
            CardId = cardId;
            Card = card;
            Currency = type;
            Balance = balance;
        }
        public CurrencyAccount()
        {
            Card = new CardEntity();
        }
        public Guid Id { get; private set; }
            = Guid.Empty;
        public Guid CardId { get; private set; }
            = Guid.Empty;
        public CardEntity Card { get; private set; }
            = new CardEntity();
        public CurrencyId Currency { get; private set; }
            = CurrencyId.None;
        public decimal Balance { get; private set; }
            = decimal.Zero;
    }
}
