CREATE TABLE [dbo].[Emprunt] (
    [EmpruntId] INT IDENTITY(1,1) NOT NULL ,
    [JeuId] INT NOT NULL,
    [PreteurId] INT NOT NULL,
    [EmprunteurId] INT NOT NULL,
    [DateEmprunt] DATETIME NOT NULL DEFAULT GETDATE(),
    [DateRetour] DATETIME NULL,
	[EtatIdNom] NVARCHAR(50) NOT NULL,
    [EvaluationPreteur] INT ,
    [EvaluationEmprunteur] INT ,
    CONSTRAINT PK_Emprunt PRIMARY KEY ([EmpruntId]),
	CONSTRAINT FK_Emprunt_Etat FOREIGN KEY ([EtatIdNom]) REFERENCES [dbo].[Etat]([Nom]) ON DELETE NO ACTION,
    CONSTRAINT FK_Emprunt_Jeu FOREIGN KEY ([JeuId]) REFERENCES [dbo].[Jeux]([JeuId]) ON DELETE CASCADE,
    CONSTRAINT FK_Emprunt_Preteur FOREIGN KEY ([PreteurId]) REFERENCES [dbo].[Utilisateur]([UtilisateurId]) ON DELETE NO ACTION,
    CONSTRAINT FK_Emprunt_Emprunteur FOREIGN KEY ([EmprunteurId]) REFERENCES [dbo].[Utilisateur]([UtilisateurId]) ON DELETE NO ACTION,
    CONSTRAINT CK_Emprunt_EvaluationPreteur CHECK ([EvaluationPreteur] BETWEEN 0 AND 5),
    CONSTRAINT CK_Emprunt_EvaluationEmprunteur CHECK ([EvaluationEmprunteur] BETWEEN 0 AND 5),
	CONSTRAINT CK_Emprunt_Etat CHECK ([EtatIdNom] NOT IN ('Incomplet'))
);