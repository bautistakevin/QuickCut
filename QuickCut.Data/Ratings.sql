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