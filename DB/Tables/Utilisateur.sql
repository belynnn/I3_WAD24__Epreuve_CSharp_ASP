CREATE TABLE [dbo].[Utilisateur]
(
    [UtilisateurId] INT IDENTITY(1,1) NOT NULL ,
    [Email] NVARCHAR(320) NOT NULL,
    [MotDePasse] VARBINARY(32) NOT NULL,
    [Pseudo] NVARCHAR(50) NOT NULL,
    [DateCreation] DATETIME NOT NULL DEFAULT GETDATE(),
    [DateDesactivation] DATETIME NULL,
	[Salt] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT PK_Utilisateur PRIMARY KEY ([UtilisateurId])
);