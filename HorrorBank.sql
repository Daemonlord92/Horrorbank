CREATE DATABASE [horrorbank];
GO

CREATE TABLE horrorbank.dbo.user_profile
(
	[UserId] NUMERIC(4,0) IDENTITY(1,1) CONSTRAINT pk_UserId PRIMARY KEY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[EmailId] VARCHAR(255) CONSTRAINT uq_EmailId UNIQUE NOT NULL,
	[Address] VARCHAR(300) NOT NULL,
);
GO
CREATE TABLE horrorbank.dbo.user_crendentials
(
	[UserName] VARCHAR(300) CONSTRAINT pk_UserName PRIMARY KEY NOT NULL,
	[Password] VARCHAR(MAX) NOT NULL,
	[UserId] NUMERIC(4,0) FOREIGN KEY REFERENCES horrorbank.dbo.user_profile(UserId)
);
GO
CREATE TABLE horrorbank.dbo.user_account
(
	[AccountNumber] NUMERIC(4,0) IDENTITY(1,1) CONSTRAINT pk_AccountNumber PRIMARY KEY,
	[Balance] NUMERIC(10,2) NOT NULL,
	[UserId] NUMERIC(4,0) FOREIGN KEY REFERENCES horrorbank.dbo.user_profile(UserId)
);
GO