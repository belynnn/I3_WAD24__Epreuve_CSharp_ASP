CREATE TABLE [dbo].[Emprunt] (
    [EmpruntId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [JeuId] INT NOT NULL,
    [PreteurId] INT NOT NULL,
    [EmprunteurId] INT NOT NULL,
    [DateEmprunt] DATETIME NOT NULL DEFAULT GETDATE(),
    [DateRetour] DATETIME NULL,
    [EvaluationPreteur] INT CHECK ([EvaluationPreteur] BETWEEN 0 AND 5),
    [EvaluationEmprunteur] INT CHECK ([EvaluationEmprunteur] BETWEEN 0 AND 5),
    FOREIGN KEY ([JeuId]) REFERENCES [dbo].[Jeux]([JeuId]) ON DELETE CASCADE,
    FOREIGN KEY ([PreteurId]) REFERENCES [dbo].[Utilisateur]([UtilisateurId]) ON DELETE NO ACTION,
    FOREIGN KEY ([EmprunteurId]) REFERENCES [dbo].[Utilisateur]([UtilisateurId]) ON DELETE NO ACTION
);