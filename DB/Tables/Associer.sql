CREATE TABLE [dbo].[Associer] (
    [JeuId] INT NOT NULL,
    [TagId] INT NOT NULL,
    CONSTRAINT PK_Associer PRIMARY KEY ([JeuId], [TagId]),
    CONSTRAINT FK_Associer_Jeu FOREIGN KEY ([JeuId]) REFERENCES [dbo].[Jeux]([JeuId]) ON DELETE CASCADE,
    CONSTRAINT FK_Associer_Tag FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tag]([TagId]) ON DELETE CASCADE
);