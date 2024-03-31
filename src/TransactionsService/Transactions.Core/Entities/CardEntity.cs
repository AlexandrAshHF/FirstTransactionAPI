using Shared.Core.Enums;
using Transactions.Core.Enums;

namespace Transactions.Core.Entities
{
    public class CardEntity
    {
        public CardEntity(Guid id, string holder, string bank,
            string number, string code, DateOnly valid,
            List<Tuple<CurrencyId, decimal>> typeAccounts, PaymentNetwrok network, Guid user,
            List<TransactionEntity>? sentTransactions = null,
            List<TransactionEntity>? receivedTransactions = null)
        {
            Id = id;
            HolderName = holder;
            BankName = bank;
            Number = number;
            AuthenticityCode = code;
            Validity = valid;

            CurrencyAccounts = typeAccounts
                .Select(x => new CurrencyAccount(Guid.NewGuid(), Id, this, x.Item1, x.Item2))
                .ToList();

            PaymentNetwrok = network;
            UserId = user;
            SentTransactions = sentTransactions;
            ReceivedTransactions = receivedTransactions;
        }
        public CardEntity()
        {
            CurrencyAccounts = new List<CurrencyAccount>();
            SentTransactions = new List<TransactionEntity> { };
            ReceivedTransactions = new List<TransactionEntity>();
        }
        public Guid Id { get; private set; }
            = Guid.Empty;
        public string HolderName { get; private set; }
            = string.Empty;
        public string BankName { get; private set; }
            = string.Empty;
        public string Number { get; private set; }
            = string.Empty;
        public string AuthenticityCode { get; private set; }
            = string.Empty;
        public DateOnly Validity { get; private set; }
            = DateOnly.MinValue;
        public List<CurrencyAccount> CurrencyAccounts { get; private set; }
            = new List<CurrencyAccount>();
        public PaymentNetwrok PaymentNetwrok { get; private set; }
            = PaymentNetwrok.None;
        public Guid UserId { get; private set; }
            = Guid.Empty;
        public List<TransactionEntity>? SentTransactions { get; private set; }
            = new List<TransactionEntity>();
        public List<TransactionEntity>? ReceivedTransactions { get; private set; }
            = new List<TransactionEntity>();
    }
}