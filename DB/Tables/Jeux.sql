CREATE TABLE [dbo].[Jeux] (
    [JeuId] INT IDENTITY(1,1) NOT NULL ,
    [Nom] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [AgeMin] INT NOT NULL,
    [AgeMax] INT NOT NULL,
    [NbJoueurMin] INT NOT NULL,
    [NbJoueurMax] INT NOT NULL,
    [DureeMinute] INT NULL,
    [DateCreation] DATETIME NOT NULL DEFAULT GETDATE(),
	[DateDesactivation] DATETIME NULL,
    CONSTRAINT PK_Jeux PRIMARY KEY ([JeuId]),
    CONSTRAINT CHK_Jeux_Age CHECK ([AgeMin] < [AgeMax]),
    CONSTRAINT CHK_Jeux_NbJoueur CHECK ([NbJoueurMin] <= [NbJoueurMax])
);