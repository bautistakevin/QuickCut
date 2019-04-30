CREATE TABLE [dbo].[Appointments]
(
  	[AppointmentID] 	INT	    IDENTITY(1, 1) NOT NULL,
  	[BarberID]		INT 	    NOT NULL,
  	[ConsumerID]		INT	    NOT NULL,
  	[Date] 			DATETIME    NOT NULL,
  	PRIMARY KEY CLUSTERED ([AppointmentID] ASC),
        CONSTRAINT [FK_dbo.Appointments_dbo.Barber_BarberID] FOREIGN KEY ([BarberID]) 
            	REFERENCES [dbo].[Barber] ([BarberID]) ON DELETE CASCADE,
    	CONSTRAINT [FK_dbo.Appointments_dbo.Consumer_ConsumerID] FOREIGN KEY ([ConsumerID]) 
        	REFERENCES [dbo].[Consumer] ([ConsumerID]) ON DELETE CASCADE
);