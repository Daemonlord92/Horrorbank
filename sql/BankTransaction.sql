CREATE TABLE horrorbank.dbo.transaction_details
(
	[TransactionId] NUMERIC(9,0) IDENTITY(1,1) CONSTRAINT pk_TransactionId PRIMARY KEY,
	[FromAccountNumber] NUMERIC(4,0) CONSTRAINT fk_FromAccoNum FOREIGN KEY REFERENCES horrorbank.dbo.user_account(AccountNumber),
	[ToAccountNumber] NUMERIC(4,0) CONSTRAINT fk_ToAccoNum FOREIGN KEY REFERENCES horrorbank.dbo.user_account(AccountNumber),
	[TransactionAmount] NUMERIC(9,2) NOT NULL
)