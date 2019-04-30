CREATE TABLE [dbo].[Barber]
(
	[BarberID]			INT		IDENTITY (1, 1) NOT NULL,
	[FirstName]			VARCHAR(50) NOT NULL,
	[LastName]			VARCHAR(50) NOT NULL,
	[BarberAddress]			VARCHAR(50) NOT NULL,
	[Zip]				INT		NOT NULL,
	PRIMARY KEY CLUSTERED ([BarberID] ASC)
);
GO;
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
GO;
CREATE TABLE [dbo].[Services]
(
	[BarberID]			INT		 NOT NULL,
	[ServiceTitle]			VARCHAR(50) NOT NULL,
	[ServiceDescription]		VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([BarberID] ASC),
	CONSTRAINT [FK_dbo.Services_dbo.Barber_BarberID] FOREIGN KEY ([BarberID]) 
            	REFERENCES [dbo].[Barber] ([BarberID]) ON DELETE CASCADE
);
GO;
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
GO;
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
GO;
CREATE TABLE [dbo].[Ratings]
(
	[RatingID]		INT	    IDENTITY (1, 1) NOT NULL,
	[BarberID]		INT 	    NOT NULL,
	[ConsumerID]		INT	    NOT NULL,
	[RatingNumber]		INT 	    NOT NULL,
	[Comments]		VARCHAR(200),
	PRIMARY KEY CLUSTERED ([RatingID] ASC),
    CONSTRAINT [FK_dbo.Ratings_dbo.Barber_BarberID] FOREIGN KEY ([BarberID]) 
            REFERENCES [dbo].[Barber] ([BarberID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Ratings_dbo.Consumer_ConsumerID] FOREIGN KEY ([ConsumerID]) 
        	REFERENCES [dbo].[Consumer] ([ConsumerID]) ON DELETE CASCADE
);
GO;
CREATE TABLE [dbo].[ZIP]
(
  	[Zip]			INT		 NOT NULL,
  	[City] 			VARCHAR(50) 	NOT NULL,
  	[State] 		VARCHAR(50) 	NOT NULL,
  	[Country] 		VARCHAR(50) 	NOT NULL,
  	PRIMARY KEY CLUSTERED ([Zip] ASC)
);
