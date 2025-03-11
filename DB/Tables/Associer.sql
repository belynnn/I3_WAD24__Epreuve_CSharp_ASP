CREATE TABLE [dbo].[Associer] (
    [JeuId] INT NOT NULL,
    [TagId] INT NOT NULL,
    PRIMARY KEY ([JeuId], [TagId]),
    FOREIGN KEY ([JeuId]) REFERENCES [dbo].[Jeux]([JeuId]) ON DELETE CASCADE,
    FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tag]([TagId]) ON DELETE CASCADE
);