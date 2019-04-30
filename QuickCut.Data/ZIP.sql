
CREATE TABLE [dbo].[ZIP]
(
  	[Zip]			INT		 NOT NULL,
  	[City] 			VARCHAR(50) 	NOT NULL,
  	[State] 		VARCHAR(50) 	NOT NULL,
  	[Country] 		VARCHAR(50) 	NOT NULL,
  	PRIMARY KEY CLUSTERED ([Zip] ASC)
);