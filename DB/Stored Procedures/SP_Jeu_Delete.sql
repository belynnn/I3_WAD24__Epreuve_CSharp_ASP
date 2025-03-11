CREATE PROCEDURE [dbo].[SP_Jeu_Delete]
CREATE PROCEDURE [dbo].[SP_Jeu_Delete]
@JeuId INT
AS
BEGIN
    IF EXISTS (SELECT 1
               FROM   [dbo].[Jeux]
               WHERE  [JeuId] = @JeuId)
        BEGIN
            DECLARE @InconnuId AS INT = -1;
            -- Ne pas mettre à jour JeuId car c'est une colonne IDENTITY
            UPDATE [dbo].[Jeux]
            SET    [Nom]          = 'Jeu Inconnu',
                   [Description]  = 'Jeu supprimé',
                   [EtatId]       = NULL,
                   [DateCreation] = NULL
            WHERE  [JeuId] = @JeuId;

            -- Mettre à jour les tables Posseder et Emprunt en remplaçant le JeuId
            UPDATE [dbo].[Posseder]
            SET    [JeuId] = @InconnuId
            WHERE  [JeuId] = @JeuId;

            UPDATE [dbo].[Emprunt]
            SET    [JeuId] = @InconnuId
            WHERE  [JeuId] = @JeuId;

            SELECT 'Jeu remplacé par un jeu inconnu avec succès' AS Message;
        END
    ELSE
        BEGIN
            SELECT 'Jeu non trouvé' AS Message;
        END
END
