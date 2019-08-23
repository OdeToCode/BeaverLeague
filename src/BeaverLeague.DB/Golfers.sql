CREATE TABLE [dbo].[Golfers]
(
	[Id] INT NOT NULL PRIMARY KEY Identity,
	[Handicap] INT NOT NULL,
	[Active] BIT NOT NULL,
	[FirstName] nvarchar(80) NOT NULL,
	[LastName] nvarchar(80) NOT NULL,
	[EmailAddress] nvarchar(80) NOT NULL,
	[PhoneNumber] nvarchar(80) NOT NULL,
	[TeeType] INT NOT NULL
)