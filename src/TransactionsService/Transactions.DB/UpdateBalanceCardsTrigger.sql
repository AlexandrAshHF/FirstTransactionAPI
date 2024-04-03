use applicationdb
go

create trigger UpdateBalanceCards on Transactions
after insert as 
begin
	update CurrencyAccounts
	set Balance = Balance + inserted.TransferAmount
	from inserted
	where CardId = inserted.ConsumerCardId and Currency = inserted.CurrencyConsumer;

	update CurrencyAccounts
	set Balance = Balance - inserted.TransferAmount
	from inserted
	where CardId = inserted.SenderCardId and Currency = inserted.CurrencySender;
end