CREATE TABLE [dbo].[Barber]
(
	[BarberID]			INT		IDENTITY (1, 1) NOT NULL,
	[FirstName]			VARCHAR(50) NOT NULL,
	[LastName]			VARCHAR(50) NOT NULL,
	[BarberAddress]			VARCHAR(50) NOT NULL,
	[Zip]				INT		NOT NULL,
	PRIMARY KEY CLUSTERED ([BarberID] ASC)
);