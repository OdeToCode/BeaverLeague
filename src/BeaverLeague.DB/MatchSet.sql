CREATE TABLE [dbo].[MatchSets]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Date] datetime NOT NULL,
	[SeasonID] INT NOT NULL,
	CONSTRAINT FK_MatchSets_Seasons FOREIGN KEY (SeasonID) REFERENCES Seasons(Id)
)
