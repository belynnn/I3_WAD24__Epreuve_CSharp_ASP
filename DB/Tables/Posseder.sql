CREATE TABLE [dbo].[Posseder] (
    [UtilisateurId] INT NOT NULL,
    [JeuId] INT NOT NULL,
    [EtatId] INT NOT NULL,
    PRIMARY KEY ([UtilisateurId], [JeuId]),
    FOREIGN KEY ([UtilisateurId]) REFERENCES [dbo].[Utilisateur]([UtilisateurId]) ON DELETE CASCADE,
    FOREIGN KEY ([JeuId]) REFERENCES [dbo].[Jeux]([JeuId]) ON DELETE CASCADE,
    FOREIGN KEY ([EtatId]) REFERENCES [dbo].[Etat]([EtatId])
);