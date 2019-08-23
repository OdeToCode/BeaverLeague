CREATE TABLE [dbo].[MatchResults]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	PlayerOneId INT NOT NULL,
	PlayerTwoId INT NOT NULL,
	CONSTRAINT FK_MatchResults_PlayerResults_One FOREIGN KEY (PlayerOneId) REFERENCES PlayerResults(Id),
	CONSTRAINT FK_MatchResults_PlayerResults_Two FOREIGN KEY (PlayerTwoId) REFERENCES PlayerResults(Id)
)
