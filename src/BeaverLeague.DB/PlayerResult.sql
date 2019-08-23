CREATE TABLE [dbo].[PlayerResults]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[GolferID] INT NOT NULL,
	Score INT NOT NULL,
	Strokes INT NOT NULL,
	PlayNext bit NOT NULL,
	Points decimal(5,2) NOT NULL,
	CONSTRAINT FK_PlayerResults_Golfers FOREIGN KEY (GolferId) REFERENCES Golfers(Id)
)
