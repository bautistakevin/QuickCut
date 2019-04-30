CREATE TABLE [dbo].[Consumer]
(
  	[ConsumerID]		INT		IDENTITY (1, 1) NOT NULL,
  	[FirstName]		VARCHAR(50) 	NOT NULL,
  	[LastName]		VARCHAR(50) 	NOT NULL,
  	[Address]		VARCHAR(50) 	NOT NULL,
  	[Zip]			VARCHAR(5) 	NOT NULL,
  	[Email]			VARCHAR(50) 	NOT NULL,
  	[PhoneNumber]		VARCHAR(12) 		NULL,
  	PRIMARY KEY CLUSTERED ([ConsumerID] ASC)
);