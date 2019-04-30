CREATE TABLE [dbo].[Services]
(
	[BarberID]			INT		 NOT NULL,
	[ServiceTitle]			VARCHAR(50) NOT NULL,
	[ServiceDescription]		VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([BarberID] ASC),
	CONSTRAINT [FK_dbo.Services_dbo.Barber_BarberID] FOREIGN KEY ([BarberID]) 
            	REFERENCES [dbo].[Barber] ([BarberID]) ON DELETE CASCADE
);