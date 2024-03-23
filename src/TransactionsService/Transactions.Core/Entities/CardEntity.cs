﻿using Transactions.Core.Enums;

namespace Transactions.Core.Entities
{
    public class CardEntity
    {
        public CardEntity(Guid id, string holder, string bank,
            string number, string code, DateOnly valid, decimal money,
            List<CurrencyType>types, PaymentNetwrok network, Guid user,
            List<TransactionEntity>?transactions = null) 
        {
            Id = id;
            HolderName = holder;
            BankName = bank;
            Number = number;
            AuthenticityCode = code;
            Validity = valid;
            Money = money;
            Currencies = types;
            PaymentNetwrok = network;
            UserId = user;
            Transactions = transactions;
        }
        public Guid Id { get; private set; }
        public string HolderName { get; private set; }
        public string BankName { get; private set; }
        public string Number { get; private set; }
        public string AuthenticityCode { get; private set; }
        public DateOnly Validity { get; private set; }
        public decimal Money { get; private set; }
        public List<CurrencyType> Currencies { get; private set; }
        public PaymentNetwrok PaymentNetwrok { get; private set; }
        public Guid UserId { get; private set; }
        public List<TransactionEntity>? Transactions { get; private set; }
    }
}