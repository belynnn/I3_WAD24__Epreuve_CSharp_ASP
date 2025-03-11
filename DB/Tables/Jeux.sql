CREATE TABLE [dbo].[Jeux] (
    [JeuId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nom] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [AgeMin] INT NOT NULL,
    [AgeMax] INT NOT NULL,
    [NbJoueurMin] INT NOT NULL,
    [NbJoueurMax] INT NOT NULL,
    [DureeMinute] INT NULL,
    [DateCreation] DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT CHK_Age CHECK ([AgeMin] < [AgeMax]),
    CONSTRAINT CHK_NbJoueur CHECK ([NbJoueurMin] < [NbJoueurMax])
);