CREATE TABLE [dbo].[BarberDetails]
(
  	[BarberID]		INT 		NOT NULL,
  	[PhoneNumber] 		VARCHAR(12) 		NOT NULL,  
  	[OperationHours] 	VARCHAR(50) 		NOT NULL,
  	[DaysOfWeek] 		VARCHAR(50) 	NOT NULL,
  	[PolicyInfo] 		VARCHAR(300)	NOT NULL,
	PRIMARY KEY CLUSTERED ([BarberID] ASC),
     CONSTRAINT [FK_dbo.BarberDetails_dbo.Barber_BarberID] FOREIGN KEY ([BarberID]) 
            REFERENCES [dbo].[Barber] ([BarberID]) ON DELETE CASCADE
);