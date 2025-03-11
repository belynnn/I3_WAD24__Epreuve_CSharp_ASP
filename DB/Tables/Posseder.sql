CREATE TABLE [dbo].[Posseder] (
    [UtilisateurId] INT NOT NULL,
    [JeuId] INT NOT NULL,
    [EtatId] INT NOT NULL,
    CONSTRAINT PK_Posseder PRIMARY KEY ([UtilisateurId], [JeuId]),
    CONSTRAINT FK_Posseder_Utilisateur FOREIGN KEY ([UtilisateurId]) REFERENCES [dbo].[Utilisateur]([UtilisateurId]) ON DELETE CASCADE,
    CONSTRAINT FK_Posseder_Jeu FOREIGN KEY ([JeuId]) REFERENCES [dbo].[Jeux]([JeuId]) ON DELETE CASCADE,
    CONSTRAINT FK_Posseder_Etat FOREIGN KEY ([EtatId]) REFERENCES [dbo].[Etat]([EtatId])
);