CREATE PROCEDURE [dbo].[SP_Jeu_Delete]
@JeuId INT
AS
BEGIN
    IF EXISTS (SELECT 1
               FROM   [dbo].[Jeux]
               WHERE  [JeuId] = @JeuId)
        BEGIN
            -- Désactiver le jeu en mettant à jour la colonne DateDesactivation
            UPDATE [dbo].[Jeux]
            SET    [DateDesactivation] = GETDATE()  -- Enregistre la date de désactivation
            WHERE  [JeuId] = @JeuId;

            -- Mettre à jour les tables Posseder et Emprunt en remplaçant le JeuId par un ID inconnu (-1)
            DECLARE @InconnuId AS INT = -1;

            UPDATE [dbo].[Posseder]
            SET    [JeuId] = @InconnuId
            WHERE  [JeuId] = @JeuId;

            UPDATE [dbo].[Emprunt]
            SET    [JeuId] = @InconnuId
            WHERE  [JeuId] = @JeuId;

            SELECT 'Jeu désactivé avec succès' AS Message;
        END
    ELSE
        BEGIN
            SELECT 'Jeu non trouvé' AS Message;
        END
END