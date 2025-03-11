CREATE TABLE [dbo].[Utilisateur]
(
    [UtilisateurId] INT IDENTITY(1,1) NOT NULL ,
    [Email] NVARCHAR(50) NOT NULL,
    [MotDePasse] NVARCHAR(255) NOT NULL,
    [Pseudo] NVARCHAR(50) NOT NULL,
    [DateCreation] DATETIME NOT NULL DEFAULT GETDATE(),
    [DateDesactivation] DATETIME NULL,
	[Salt] UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
    CONSTRAINT PK_Utilisateur PRIMARY KEY ([UtilisateurId])
);