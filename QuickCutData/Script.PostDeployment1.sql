/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
MERGE INTO Barber AS Target 
USING (VALUES 
        (1, 'Chuck', 'Norris', '123 Infinity Dr.','32201'), 
        (2, 'Kendrick', 'Lamar', '321 Finite Loop','90223')
) 
AS Source (BarberID, FirstName, LastName, BarberAddress, Zip) 
ON Target.BarberID = Source.BarberID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (FirstName, LastName, BarberAddress, Zip) 
VALUES (FirstName, LastName, BarberAddress, Zip);

MERGE INTO BarberDetails AS Target 
USING (VALUES 
        (1, '813-123-4569', '10 A.M to 7 P.M', 'Mon - Sat','No refunds'), 
        (2, '813-134-4234', '6 A.M to 7 P.M', 'Wed - Sat','Cancellation fee')
) 
AS Source (BarberID, PhoneNumber, OperationHours, DaysOfWeek, PolicyInfo) 
ON Target.BarberID = Source.BarberID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (BarberID, PhoneNumber, OperationHours, DaysOfWeek, PolicyInfo) 
VALUES (BarberID, PhoneNumber, OperationHours, DaysOfWeek, PolicyInfo);

MERGE INTO Services AS Target 
USING (VALUES 
        (1, 'High Fade', 'A High Fade Haircut, fade can be skin tight or 0'), 
        (2, 'Shape-up', 'not wanting a haircut? get a Shape-up')
) 
AS Source (BarberID, ServiceTitle, ServiceDescription) 
ON Target.BarberID = Source.BarberID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (BarberID, ServiceTitle, ServiceDescription) 
VALUES (BarberID, ServiceTitle, ServiceDescription);

MERGE INTO Consumer AS Target
USING (VALUES 
        (1, 'Kevin', 'Bautista', '1247 Loquat Ct','32043', 'kevinB@outlook.com', '813-629-9607'), 
        (2, 'Joe', 'Schmoe', '880 Baymedows Dr.','32212', 'joeS@gmail.com', '407-249-5939'), 
        (3, 'Tabitha', 'Catlover', '1247 Liquid St','77010', 'tabithalovescats@yahoo.com', '904-542-3698') 
)
AS Source (ConsumerID, FirstName, LastName, Address, Zip, Email, PhoneNumber)
ON Target.ConsumerID = Source.ConsumerID
WHEN NOT MATCHED BY TARGET THEN
INSERT (FirstName, LastName, Address, Zip, Email, PhoneNumber)
VALUES (FirstName, LastName, Address, Zip, Email, PhoneNumber);

MERGE INTO Appointments AS Target 
USING (VALUES 
        (1, 1, 1, '20180513 18:45:01'), 
        (2, 2, 1, '20180513 18:45:01') 
) 
AS Source (AppointmentID, BarberID, ConsumerID, Date) 
ON Target.AppointmentID = Source.AppointmentID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (BarberID, ConsumerID, Date) 
VALUES (BarberID, ConsumerID, Date);

MERGE INTO Ratings AS Target 
USING (VALUES 
        (1, 1, 1, 2, 'this barber sucks!'), 
        (2, 2, 2, 5, 'this guy can cut some hair!')
) 
AS Source (RatingID, BarberID, ConsumerID, RatingNumber, Comments) 
ON Target.RatingID = Source.RatingID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (BarberID, ConsumerID, RatingNumber, Comments) 
VALUES (BarberID, ConsumerID, RatingNumber, Comments);

MERGE INTO ZIP AS Target
USING (VALUES
        (32201, 'Jacksonville', 'Florida', 'US'),
        (90223, 'Compton', 'California', 'US'),
        (32043, 'Green Cove Springs', 'Florida', 'US'),
        (32212, 'Jacksonville', 'Florida', 'US'),
        (77010, 'Houston', 'Texas', 'US')
)
AS Source (Zip, City, State, Country) 
ON Target.Zip = Source.Zip 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Zip, City, State, Country) 
VALUES (Zip, City, State, Country);